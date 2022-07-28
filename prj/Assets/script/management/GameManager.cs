using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.IO;

public class GameManager : Singleton<GameManager>
{
    public int savePointNow;

    public int deathCountTotal;
    public int deathCountStage;
    
    public float time_total;
    public float timeNow;

    public int dataNum;
    public string[] path = new string[3];

    public bool isGameOver;
    public bool isPaused;


    public void Awake()
    {

        base.Awake();
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = Path.Combine(Application.dataPath, "DATA", "data" + (i + 1).ToString() + ".json");
        }
        isGameOver = false;
        isPaused = false;

    }
    private void Update()
    {
 

    }
    public void GameOver()
    {
        StartCoroutine(GameOverCo());
    }
    IEnumerator GameOverCo()
    {

        deathCountStage++;
        deathCountTotal++;
        yield return new WaitForSeconds(1f);
        isGameOver = true;
        SaveJason();
        Time.timeScale = 0;
        
        
        
        
        
        
        //SceneManager.LoadScene("Menu");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  
    }
    public void SaveJason()
    {



        Data data = new Data();
        data.SetData(dataNum, savePointNow, deathCountTotal, deathCountStage, time_total, timeNow);
        string jdata = JsonConvert.SerializeObject(data);
        
        File.WriteAllText(path[dataNum - 1], jdata);

    }


    //public void loadDATA(int num)
    //{
    //    string jdata = File.ReadAllText(Application.dataPath + "/DATA"+num+".json");
    //    //byte[] bytes = System.Convert.FromBase64String(jdata);
    //    //string reformat = System.Text.Encoding.UTF8.GetString(bytes);
        
    //    Data data = JsonConvert.DeserializeObject<Data>(jdata);
    //    savePointNow = data.savePoint;
    //    deathCountTotal=data.deathCountTotal;
    //    deathCountStage = data.deathCountStage;
    //    time_total = data.timeTotal;
    //    timeNow = data.timeStage;

    //}

    public string Timer(float timeNow)
    {
        int[] nTimeText = new int[3];
        string[] sTimeText = new string[3];

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


}
