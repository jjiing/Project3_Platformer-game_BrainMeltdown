using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int savePointNow;

    public void Awake()
    {
        savePointNow = 1;
        base.Awake();

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
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  
    }
    


}
