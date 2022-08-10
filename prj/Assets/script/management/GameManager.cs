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
    public bool isDead;
    public bool isClear;


    public void Awake()
    {

        base.Awake();
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = Path.Combine(Application.dataPath, "DATA", "data" + (i + 1).ToString() + ".json");
        }
        isGameOver = false;
        isPaused = false;
        isDead = false;
        isClear = false;
        

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
        AudioManager.Instance.StopSE(constant.BACKGROUND_AUDIO_SOURCE);
        AudioManager.Instance.PlaySE("gameOver", constant.EFFECT_AUDIO_SOURCE);
        deathCountStage++;
        deathCountTotal++;
        
        yield return new WaitForSecondsRealtime(0.5f);
        isGameOver = true;
        SaveJason();
        
        
  
    }
    public void SaveJason()
    {

        Data data = new Data();
        data.SetData(dataNum, savePointNow, deathCountTotal, deathCountStage, time_total, timeNow);
        string jdata = JsonConvert.SerializeObject(data);

        //��ȣȭ ����
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string format = System.Convert.ToBase64String(bytes);

        File.WriteAllText(path[dataNum - 1], format);

    }




    public string Timer(float timeNow)
    {
        int[] nTimeText = new int[3];       //int ������ ����Ͽ� �����ϴ� �迭
        string[] sTimeText = new string[3]; //string ������ ��ȯ�� �����ϴ� �迭

        //���� ���� �ð��� �ð� , ��, �ʷ� ���
        nTimeText[0] = (int)Mathf.Round((int)timeNow / 3600);
        nTimeText[1] = (int)Mathf.Round((int)timeNow / 60 % 60);  
        nTimeText[2] = (int)Mathf.Round((int)timeNow % 60);


        //������ string Ÿ������ ��ȯ
        for (int i = 0; i < nTimeText.Length; i++)
        {
            if (nTimeText[i] < 1) sTimeText[i] = "00";
            else if (nTimeText[i] >= 1 && nTimeText[i] < 10)
                sTimeText[i] = "0" + nTimeText[i].ToString();
            else if (nTimeText[i] >= 10)
                sTimeText[i] = nTimeText[i].ToString();
        }

        //6���� string ���·� ��ȯ
        return sTimeText[0] + "  " + sTimeText[1] + "  " + sTimeText[2];

    }


}
