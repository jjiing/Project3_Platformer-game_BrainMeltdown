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
    

    public void Awake()
    {
        //savePointNow = 3;
        base.Awake();
        //deathCountStage = 0;
       // deathCountTotal = 0;

    }
    private void Update()
    {
        time_total += Time.deltaTime;
        timeNow += Time.deltaTime;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  
    }
    public void loadDATA(int num)
    {
        string jdata = File.ReadAllText(Application.dataPath + "/DATA"+num+".json");
        //byte[] bytes = System.Convert.FromBase64String(jdata);
        //string reformat = System.Text.Encoding.UTF8.GetString(bytes);
        
        Data data = JsonConvert.DeserializeObject<Data>(jdata);
        savePointNow = data.savePoint;
        deathCountTotal=data.deathCountTotal;
        deathCountStage = data.deathCountStage;
        time_total = data.timeTotal;
        timeNow = data.timeStage;

    }
    


}
