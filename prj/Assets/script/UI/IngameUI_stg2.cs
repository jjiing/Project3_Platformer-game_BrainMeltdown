using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI_stg2 : IngameUI
{


    private void Start()
    {
        GameManager.Instance.timeNow = 0;
        GameManager.Instance.time_total = Mathf.Round(GameManager.Instance.time_total);
        
        tryCountManange();

        
    }

    private void Update()
    {
        TimeWorking();
        SetTime();
        UpdateTimer(sTime, sTime_total);
    }

   
}
