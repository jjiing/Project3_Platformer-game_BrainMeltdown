using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnCheckParents : MonoBehaviour
{
    PlayerOnCheckChild childBlockA;
    PlayerOnCheckChild childBlockB;

    bool isPlayerOn_R;
    bool isPlayerOn_L;
    bool isBothOn;
    public GameObject landObject;
    Animator animator;
    void Start()
    {
        childBlockA = transform.GetChild(0).GetComponent<PlayerOnCheckChild>();
        childBlockB = transform.GetChild(1).GetComponent<PlayerOnCheckChild>();
        animator = landObject.GetComponent<Animator>();
        isBothOn = false;
    }


    void Update()
    {

    }
    public void CheckIsOn()
    {
        isPlayerOn_L = childBlockA.IsPlayerOn;
        isPlayerOn_R = childBlockB.IsPlayerOn;
        if (isPlayerOn_L && isPlayerOn_R) Invoke("PlayAnim", 3f);

    }

    void PlayAnim()
    {

        animator.SetTrigger("MoveDown");
    }
}
