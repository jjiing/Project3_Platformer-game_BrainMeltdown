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
    public int GameOverInt { get { return gameOverInt; }  set { gameOverInt= value;} }
    public int PauseInt { get { return pauseInt; } set { pauseInt= value;} }
    public Image[] gameOverOption = new Image[2];
    public Image[] pauseOption = new Image[4];



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

            gameOver.gameObject.SetActive(true);
            gameover_text_Timer_Total.text = sTime_total;
            gameover_text_Timer_Stage.text = sTime;
            gameover_text_DeathCountTotal.text = GameManager.Instance.deathCountTotal.ToString();
            gameover_text_DeathCountStage.text = GameManager.Instance.deathCountStage.ToString();
            tryCountManange();
            OptionSelect(GameOverInt, gameOverOption, 2);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameManager.Instance.isGameOver = false;
                gameOver.gameObject.SetActive(false);
                Time.timeScale = 1;
                if (gameOverInt == 1)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                else if (gameOverInt == 2)
                    SceneManager.LoadScene("Menu");
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
            OptionSelect(PauseInt, pauseOption, 4);
            if(Input.GetKeyDown(KeyCode.Return) && pauseInt!=4)
            {
                GameManager.Instance.isPaused = false;
                if (pauseInt == 2) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                else if (pauseInt == 3)
                {
                    GameManager.Instance.SaveJason();
                    SceneManager.LoadScene("Menu");
                    
                }      
            }
   
        }
        else
        {
            GameManager.Instance.isPaused = false;
            Time.timeScale = 1;
            paused.gameObject.SetActive(false);

        }
        
    }


    public void OptionSelect(int option, Image[] optionBox,  int limitnum)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("아래화살표");
            if (option < limitnum)
            { 
                option++;
                PauseInt++;
                Debug.Log("option : " + option+ ", pausenum : "+pauseInt); 
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        { if (option > 1) option--; }

        for (int i = 0; i < optionBox.Length; i++)
            optionBox[i].gameObject.SetActive(false);

        optionBox[option - 1].gameObject.SetActive(true);


    }
    //public string Timer(float timeNow, int[] nTimeText, string[] sTimeText)
    //{


    //    nTimeText[0] = (int)Mathf.Round((int)timeNow / 3600);
    //    nTimeText[1] = (int)Mathf.Round((int)timeNow / 60 % 60);  //60이상으로 넘어가면 안되니까 60으로 한번 더 계산
    //    nTimeText[2] = (int)Mathf.Round((int)timeNow % 60);

    //    for (int i = 0; i < nTimeText.Length; i++)
    //    {
    //        if (nTimeText[i] < 1) sTimeText[i] = "00";
    //        else if (nTimeText[i] >= 1 && nTimeText[i] < 10)
    //            sTimeText[i] = "0" + nTimeText[i].ToString();
    //        else if (nTimeText[i] >= 10)
    //            sTimeText[i] = nTimeText[i].ToString();
    //    }
        
    //    return sTimeText[0] + "  " + sTimeText[1] + "  " + sTimeText[2];
        
       
    //}
    
    public void UpdateTimer(string timeStage, string timeTotal)
    {
        text_Timer_Total.text = timeTotal;
        text_Timer_Stage.text = timeStage;
    }

    
    

}
