using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int savePointNow;

    public void Awake()
    {
        savePointNow = 6;
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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  
    }
    


}
