using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class IngameUI_stg2 : IngameUI
{
    public Image clearbox;
    public Text clear_text_Timer_Total;
    public Text clear_text_Timer_Stage;
    public Text clear_text_DeathCountTotal;
    public Text clear_text_DeathCountStage;



    private void Start()
    {
        sound.value = AudioManager.Instance.volume;
        GameManager.Instance.timeNow = 0;
        GameManager.Instance.time_total = Mathf.Round(GameManager.Instance.time_total);
        AudioManager.Instance.PlaySE("s2BGM", constant.BACKGROUND_AUDIO_SOURCE);
        tryCountManange();

        
    }

    private void Update()
    {
        TimeWorking();
        SetTime();
        UpdateTimer(sTime, sTime_total);
        GameOver();
        OnPause();
        Clear();
    }
    public void Clear()
    {
        if (GameManager.Instance.isClear)
        {
            
            Time.timeScale = 0;

            clearbox.gameObject.SetActive(true);
            clear_text_Timer_Total.text = sTime_total;
            clear_text_Timer_Stage.text = sTime;
            clear_text_DeathCountTotal.text = GameManager.Instance.deathCountTotal.ToString();
            clear_text_DeathCountStage.text = GameManager.Instance.deathCountStage.ToString();
            GameManager.Instance.SaveJason();


            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameManager.Instance.isClear = false;
                clearbox.gameObject.SetActive(false);
                Time.timeScale = 1;
                SceneManager.LoadScene("Menu");


            }
        }
        
            
          
        
    }

}
