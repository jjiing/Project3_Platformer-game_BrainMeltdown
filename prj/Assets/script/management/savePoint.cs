using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        int num = GameManager.Instance.savePointNow;
        if(int.Parse(gameObject.name.ToString().Substring(9))<=num)
            anim.SetTrigger("isArrived");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime == 0)
                AudioManager.Instance.PlaySE("savePoint", constant.EFFECT_AUDIO_SOURCE);
            anim.SetTrigger("isArrived");
            //현재 세이브 포인트보다 커야 새로운 세이브포트로 갱신
            int savePointNum = int.Parse(gameObject.name.Substring(9));
            if(savePointNum > GameManager.Instance.savePointNow)
                GameManager.Instance.savePointNow = savePointNum;
        }
    }
}
