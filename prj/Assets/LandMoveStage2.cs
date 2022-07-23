using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveStage2 : MonoBehaviour, IMoveRight
{
    float moveSpeed;
    bool isYellowOn;
    bool isPurpleOn;
    bool isTriggered;
    void Start()
    {
        moveSpeed = 2f;
        isYellowOn = false;
        isPurpleOn = false;
        isTriggered = false;
    }

    
    void Update()
    {
        if(isYellowOn && isPurpleOn && !isTriggered)
            MoveRight();
    }
    public void MoveRight()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
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
