using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnCheckChild : MonoBehaviour
{
    private bool isPlayerOn;
    PlayerOnCheckParents parentScript;



    public bool IsPlayerOn
    {
        get { return isPlayerOn; }
        set
        {
            isPlayerOn = value;
            parentScript.CheckIsOn();
        }

    }
    void Start()
    {
        isPlayerOn = false;
        
        parentScript = transform.GetComponentInParent<PlayerOnCheckParents>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsPlayerOn = true;

            
        }
    }



}
