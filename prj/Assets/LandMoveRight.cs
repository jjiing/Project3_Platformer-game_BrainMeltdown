using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveRight : MonoBehaviour, IMoveRight
{
    public bool isBothOn;

    bool isPlayerOn_R;
    bool isPlayerOn_L;

    LandMoveRightChild childLandA;
    LandMoveRightChild childLandB;

    float moveSpeed;

    private void Start()
    {
        isBothOn = false;

        childLandA = transform.GetChild(0).gameObject.GetComponent<LandMoveRightChild>();
        childLandB = transform.GetChild(1).gameObject.GetComponent<LandMoveRightChild>();
        
        moveSpeed = 1.5f;


    }
    private void Update()
    {
        
        if (isBothOn)
        {
            MoveRight();
        }
    }
    public void MoveRight()
    {
        childLandA.SetLightOn(true);
        childLandB.SetLightOn(true);
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }
    public void CheckIsOn()
    {
        isPlayerOn_L = childLandA.IsPlayerOn;
        isPlayerOn_R = childLandB.IsPlayerOn;
        if (isPlayerOn_L && isPlayerOn_R)
            isBothOn = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Trigger")
        {
            isBothOn = false;
        }
    }
}
