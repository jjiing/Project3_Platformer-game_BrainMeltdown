using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI_stg1 : IngameUI
{

    private void Update()
    {
        timeNow += Time.deltaTime;

        sTime = Timer(timeNow, clockText, sClockText);
        sTime_total = CalculateTotalTime(clockText_total, sClockText);
        UpdateTimer(sTime, sTime_total);

        if (GameManager.Instance.savePointNow ==4) TimeSave();
        
    
    }
    void TimeSave()
    {
        GameManager.Instance.stage1Cleartime = Mathf.Round(timeNow);
    }
    
    public override string CalculateTotalTime(int[] nTimeText, string[] sTimeText)
    {
        return sTime;
    }



}
