using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI_stg1 : IngameUI
{
    private void Start()
    {

        tryCountManange();
    }
    private void Update()
    {
        SetTime();
        UpdateTimer(sTime, sTime_total);
        
        
    
    }




}
