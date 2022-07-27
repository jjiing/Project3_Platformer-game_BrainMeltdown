using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{


    public string sTime;
    public string sTime_total;
    public int[] clockText = new int[3];
    public string[] sClockText = new string[3];
    public int[] clockText_total = new int[3];
    public string[] sClockText_total = new string[3];


    public Text text_Timer_Total;
    public Text text_Timer_Stage;
    public Text text_DeathCountTotal;
    public Text text_DeathCountStage;



    protected void tryCountManange()
    {
        text_DeathCountTotal.text = GameManager.Instance.deathCountTotal.ToString();
        text_DeathCountStage.text = GameManager.Instance.deathCountStage.ToString();
    }
    public void SetTime()
    {

        sTime = Timer(GameManager.Instance.timeNow, clockText, sClockText);
        sTime_total = Timer(GameManager.Instance.time_total, clockText, sClockText);
       

    }
    public string Timer(float timeNow, int[] nTimeText, string[] sTimeText)
    {


        nTimeText[0] = (int)Mathf.Round((int)timeNow / 3600);
        nTimeText[1] = (int)Mathf.Round((int)timeNow / 60 % 60);  //60이상으로 넘어가면 안되니까 60으로 한번 더 계산
        nTimeText[2] = (int)Mathf.Round((int)timeNow % 60);

        for (int i = 0; i < nTimeText.Length; i++)
        {
            if (nTimeText[i] < 1) sTimeText[i] = "00";
            else if (nTimeText[i] >= 1 && nTimeText[i] < 10)
                sTimeText[i] = "0" + nTimeText[i].ToString();
            else if (nTimeText[i] >= 10)
                sTimeText[i] = nTimeText[i].ToString();
        }
        
        return sTimeText[0] + "  " + sTimeText[1] + "  " + sTimeText[2];
        
       
    }
    
    public void UpdateTimer(string timeStage, string timeTotal)
    {
        text_Timer_Total.text = timeTotal;
        text_Timer_Stage.text = timeStage;
    }

    
    

}
