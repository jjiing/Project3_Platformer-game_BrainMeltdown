using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI_stg2 : IngameUI
{


    private void Start()
    {
        time_total = GameManager.Instance.stage1Cleartime;
        
    }

    private void Update()
    {
        timeNow += Time.deltaTime;
        time_total += Time.deltaTime;

        sTime = Timer(timeNow, clockText, sClockText);
        sTime_total = CalculateTotalTime(clockText_total,sClockText_total);
        UpdateTimer(sTime, sTime_total);
    }

    public override string CalculateTotalTime(int[] nTimeText, string[] sTimeText)
    {
        
        return Timer(time_total, nTimeText, sTimeText);
        
        
    }
}
