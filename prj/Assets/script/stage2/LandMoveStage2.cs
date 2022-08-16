using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveStage2 : MonoBehaviour, IMoveRight
{
    float moveSpeed;
    bool isYellowOn;
    bool isPurpleOn;
    bool isTriggered;
    bool isAttackStart;

    public GameObject rowNotice;
    public GameObject columnNotice;
    SpriteRenderer rowSR;
    SpriteRenderer columnSR;

    public GameObject projective;
    Projective4ways projectiveScript;

    
    void Start()
    {
        moveSpeed = 2f;
        isYellowOn = false;
        isPurpleOn = false;
        isTriggered = false;
        isAttackStart = false;
        
        rowSR = rowNotice.GetComponent<SpriteRenderer>();
        columnSR = columnNotice.GetComponent<SpriteRenderer>();
        rowNotice.SetActive(false);
        columnNotice.SetActive(false);
        
        projective.SetActive(false);
        projectiveScript = projective.GetComponent<Projective4ways>();

    }

    
    void Update()
    {
        if (isYellowOn && isPurpleOn)
        {
            if(!isTriggered) MoveRight();
            if (!isTriggered && !isAttackStart) StartCoroutine(AttackCo());
        }
    }
    public void MoveRight()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }
    IEnumerator AttackCo()
    {
        isAttackStart = true;
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 4; i++)
        {
            int RandomNum = Random.Range(1,5);
            projectiveScript.wayNum = RandomNum;
            if (RandomNum == 1) StartCoroutine(AttackCo(1, new Vector3(-15, 1.3f, 0), rowNotice, rowSR));
            else if (RandomNum == 2) StartCoroutine(AttackCo(2, new Vector3(15, 1.3f, 0), rowNotice, rowSR));
            else if (RandomNum == 3) StartCoroutine(AttackCo(3, new Vector3(1.5f, 10f, 0), columnNotice, columnSR));
            else if (RandomNum == 4) StartCoroutine(AttackCo(4, new Vector3(0.5f, -10f, 0), columnNotice, columnSR));
            
            yield return new WaitForSeconds(5.5f);
        }
       


    }
    IEnumerator AttackCo(int num, Vector3 pos, GameObject dir, SpriteRenderer dirSR)
    {
        dir.SetActive(true);
        if(num ==3)
            dir.transform.position = gameObject.transform.position + new Vector3(3, 0, 0);
        else if (num ==4)
            dir.transform.position = gameObject.transform.position + new Vector3(1.5f, 0, 0);
        StartCoroutine(FadeInOutCo(dirSR));
        yield return new WaitForSeconds(1f);
        dir.SetActive(false);

        projective.SetActive(true);
        projective.transform.position = gameObject.transform.position + pos;
        yield return new WaitForSeconds(4f);
        projective.SetActive(false);
    }

    IEnumerator FadeInOutCo(SpriteRenderer sr)
    {
        Color color = sr.color;
        color.a = 0;
        sr.color = color;
        while(color.a <0.2f)
        {
            color.a +=Time.deltaTime/4f;
            sr.color = color;
            yield return null;
        }
        while(color.a >0f)
        {
            color.a -=Time.deltaTime/4f;
            sr.color= color;
            yield return null;
        }

    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isYellowOn = true;
            collision.transform.SetParent(transform);
        }
        if (collision.gameObject.layer == 9)
        {
            isPurpleOn = true;
            collision.transform.SetParent(transform);
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isTriggered)
        {
            if (collision.gameObject.layer == 8)
            {
                collision.transform.SetParent(null);
            }
            if (collision.gameObject.layer == 9)
            {
                collision.transform.SetParent(null);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Trigger")
        {
            isTriggered = true;
        }
    }
}
