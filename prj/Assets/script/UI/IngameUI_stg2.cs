using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI_stg2 : IngameUI
{


    private void Start()
    {
        
        tryCountManange();
        time_total = GameManager.Instance.stage1Cleartime;
        
    }

    private void Update()
    {
        
        time_total += Time.deltaTime;

        SetTime();
        UpdateTimer(sTime, sTime_total);
    }

    public override string CalculateTotalTime(int[] nTimeText, string[] sTimeText)
    {
        
        return Timer(time_total, nTimeText, sTimeText);
        
        
    }
}
