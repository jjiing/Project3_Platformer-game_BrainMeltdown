using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearPoint2 : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            AudioManager.Instance.StopSE(constant.BACKGROUND_AUDIO_SOURCE);
            AudioManager.Instance.PlaySE("clear", constant.EFFECT_AUDIO_SOURCE);
            
            anim.SetTrigger("isArrived");
            GameManager.Instance.savePointNow = 8;
            GameManager.Instance.isClear = true;

        }
    }
}
