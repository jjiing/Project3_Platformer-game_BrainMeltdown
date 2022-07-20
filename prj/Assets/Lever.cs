using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Animator anim;
    GameObject lever;
    public LandUpByLever landUpByLever;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            anim.SetTrigger("isWork");
            landUpByLever.isLeverWork = true;

        }
    }

    private void Start()
    {
        
        lever = transform.GetChild(0).gameObject; //첫번째 자식 오브젝트 찾기
        anim = lever.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
}
