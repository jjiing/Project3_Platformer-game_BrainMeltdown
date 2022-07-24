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
            StartCoroutine("AttackCo" + RandomNum.ToString());
            yield return new WaitForSeconds(5.5f);
        }
       


    }

    IEnumerator AttackCo1()
    { 
        rowNotice.SetActive(true);
        StartCoroutine(FadeInOutCo(rowSR));
        yield return new WaitForSeconds(1f);
        rowNotice.SetActive(false);
        
        projective.SetActive(true);
        projective.transform.position = gameObject.transform.position + new Vector3(-15, 1.3f,0);
        yield return new WaitForSeconds(4f);
        projective.SetActive(false);

    }
    IEnumerator AttackCo2()
    {
        rowNotice.SetActive(true);
        StartCoroutine(FadeInOutCo(rowSR));
        yield return new WaitForSeconds(1f);
        rowNotice.SetActive(false);
        
        projective.SetActive(true);
        projective.transform.position = gameObject.transform.position + new Vector3(15, 1.3f, 0);
        yield return new WaitForSeconds(4f);
        projective.SetActive(false);
     
    }
    IEnumerator AttackCo3()
    {
        columnNotice.SetActive(true);
        columnNotice.transform.position = gameObject.transform.position + new Vector3(3, 0, 0);
        StartCoroutine(FadeInOutCo(columnSR));
        yield return new WaitForSeconds(1f);
        columnNotice.SetActive(false);

        projective.SetActive(true);
        projective.transform.position = gameObject.transform.position + new Vector3(1.5f, 10f, 0);
        yield return new WaitForSeconds(4f);
        projective.SetActive(false);

    }
    IEnumerator AttackCo4()
    {
        columnNotice.SetActive(true);
        columnNotice.transform.position = gameObject.transform.position + new Vector3(1.5f, 0, 0);
        StartCoroutine(FadeInOutCo(columnSR));
        yield return new WaitForSeconds(1f);
        columnNotice.SetActive(false);

        projective.SetActive(true);
        projective.transform.position = gameObject.transform.position + new Vector3(0.5f, -10f, 0);
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
