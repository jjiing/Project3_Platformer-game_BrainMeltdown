using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandHalfPass : MonoBehaviour
{
    EdgeCollider2D collider;
    private void Start()
    {
        collider = GetComponent<EdgeCollider2D>();
    }


    //기본상태 trigger
    //내려올때 트리거 꺼주고, 나갈때 트리거 다시 켜줌
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>().isDown)
                collider.isTrigger = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collider.isTrigger = true;

    }
}
