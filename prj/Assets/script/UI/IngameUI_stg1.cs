using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI_stg1 : IngameUI
{
    private void Start()
    {
        AudioManager.Instance.PlaySE("s1BGM", constant.BACKGROUND_AUDIO_SOURCE);
        tryCountManange();
    }
    private void Update()
    {
        TimeWorking();
        SetTime();
        UpdateTimer(sTime, sTime_total);
        GameOver();
        OnPause();




    }




}
