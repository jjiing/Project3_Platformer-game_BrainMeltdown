using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameUI : MonoBehaviour
{


    public string sTime;
    public string sTime_total;



    public Text text_Timer_Total;
    public Text text_Timer_Stage;
    public Text text_DeathCountTotal;
    public Text text_DeathCountStage;

    public Image gameOver;
    public Text gameover_text_Timer_Total;
    public Text gameover_text_Timer_Stage;
    public Text gameover_text_DeathCountTotal;
    public Text gameover_text_DeathCountStage;

    public Image paused;


    public int gameOverInt=1;
    public int pauseInt=1;

   
    public Image[] gameOverOption = new Image[2];
    public Image[] pauseOption = new Image[4];

    public Slider sound;


    protected void tryCountManange()
    {
        text_DeathCountTotal.text = GameManager.Instance.deathCountTotal.ToString();
        text_DeathCountStage.text = GameManager.Instance.deathCountStage.ToString();
    }
    public void TimeWorking()
    {
        GameManager.Instance.time_total += Time.deltaTime;
        GameManager.Instance.timeNow += Time.deltaTime;
    }
    public void SetTime()
    {

        sTime = GameManager.Instance.Timer(GameManager.Instance.timeNow);
        sTime_total = GameManager.Instance.Timer(GameManager.Instance.time_total);
       

    }
    public void GameOver()
    {
        if (GameManager.Instance.isGameOver)
        {

            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            gameover_text_Timer_Total.text = sTime_total;
            gameover_text_Timer_Stage.text = sTime;
            gameover_text_DeathCountTotal.text = GameManager.Instance.deathCountTotal.ToString();
            gameover_text_DeathCountStage.text = GameManager.Instance.deathCountStage.ToString();
            tryCountManange();
            OptionSelect(2, gameOverInt, gameOverOption, 2);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                AudioManager.Instance.PlaySE("click", constant.EFFECT_AUDIO_SOURCE);
                GameManager.Instance.isDead = false;
                GameManager.Instance.isGameOver = false;
                gameOver.gameObject.SetActive(false);
                Time.timeScale = 1;
                switch(gameOverInt)
                {
                    case 1:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        break;
                    case 2:
                        SceneManager.LoadScene("Menu");
                        break;

                }

                    
            }
        }
    }
    public void OnPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.isPaused = true;
        if(GameManager.Instance.isPaused)
        {
            Time.timeScale = 0;
            paused.gameObject.SetActive(true);
            
            OptionSelect(1, pauseInt, pauseOption, 4);
            if(Input.GetKeyDown(KeyCode.Return) && pauseInt!=4)
            {
                AudioManager.Instance.PlaySE("click", constant.EFFECT_AUDIO_SOURCE);
                GameManager.Instance.isPaused = false;
                switch(pauseInt)
                {
                    case 2:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        break;
                    case 3:
                       
                        GameManager.Instance.SaveJason();
                        SceneManager.LoadScene("Menu");
                        break;

                }     
            }
            if(pauseInt ==4)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                    sound.value += 0.1f;
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    sound.value -= 0.1f;
                AudioManager.Instance.volume = sound.value;
            }
   
        }
        else
        {
            GameManager.Instance.isPaused = false;
            if(!GameManager.Instance.isDead && !GameManager.Instance.isClear) Time.timeScale = 1;
            paused.gameObject.SetActive(false);

        }
        
    }


    public void OptionSelect(int caseNum, int option, Image[] optionBox,  int limitnum)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && option <limitnum)
        {
            option++;
            AudioManager.Instance.PlaySE("button", constant.EFFECT_AUDIO_SOURCE);
            switch (caseNum)
            {
                case 1:
                    pauseInt = option; break;
                case 2:
                    gameOverInt = option; break;

            }

        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && option>1)
        { 
           option--;
            AudioManager.Instance.PlaySE("button", constant.EFFECT_AUDIO_SOURCE);
            switch (caseNum)
           {
               case 1:
                   pauseInt = option; break;
               case 2:
                   gameOverInt = option; break;

            }
   
        }


        for (int i = 0; i < optionBox.Length; i++)
            optionBox[i].gameObject.SetActive(false);

        optionBox[option - 1].gameObject.SetActive(true);


    }

    
    public void UpdateTimer(string timeStage, string timeTotal)
    {
        text_Timer_Total.text = timeTotal;
        text_Timer_Stage.text = timeStage;
    }

    
    

}
