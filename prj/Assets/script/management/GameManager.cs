using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int savePointNow;
    public float stage1Cleartime;
    public int deathCountStage;
    public int deathCountTotal;
    public float timeNow;
    //public float time_total;

    public void Awake()
    {
        savePointNow = 2;
        base.Awake();
        deathCountStage = 0;
        deathCountTotal = 0;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  
    }
    


}
