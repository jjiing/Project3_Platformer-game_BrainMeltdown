using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveUpStg2 : MonoBehaviour
{
    bool isYellowOn;
    bool isPurpleOn;
    Animator anim;
    void Start()
    {
        isYellowOn = false;
        isPurpleOn = false;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (isYellowOn && isPurpleOn)
            anim.SetTrigger("isBothOn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
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
}
