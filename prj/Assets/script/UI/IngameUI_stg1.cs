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
        if (GameManager.Instance.savePointNow ==4) Stage1ClearTimeSave();
        
    
    }
    void Stage1ClearTimeSave()
    {
        GameManager.Instance.stage1Cleartime = Mathf.Round(GameManager.Instance.timeNow);
    }
    
    public override string CalculateTotalTime(int[] nTimeText, string[] sTimeText)
    {
        return sTime;
    }



}
