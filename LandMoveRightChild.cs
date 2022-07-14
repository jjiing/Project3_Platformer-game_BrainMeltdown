using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveRightChild : MonoBehaviour
{
    private bool isPlayerOn;
    GameObject childLight;
    LandMoveRight parentScript;



    public bool IsPlayerOn
    {
        get{ return isPlayerOn; }
        set 
        { 
            isPlayerOn = value;
            parentScript.CheckIsOn();
        }
        
    }
    void Start()
    {
        isPlayerOn = false;
        childLight = transform.GetChild(0).gameObject;
        parentScript = transform.GetComponentInParent<LandMoveRight>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsPlayerOn = true;
            SetLightOn(true);
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsPlayerOn = false;
            if(!parentScript.isBothOn)
                SetLightOn(false);
            collision.transform.SetParent(null);
        }
    }

    public void SetLightOn(bool isOn)
    {
        childLight.SetActive(isOn);
    }
}
