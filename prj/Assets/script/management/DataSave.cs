using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class Data
{
    public int dataNum;
    public int savePoint;

    public int deathCountTotal;
    public int deathCountStage;

    public float timeTotal;
    public float timeStage;



    public Data() { }
    public Data(int dataNum, int savePoint, int deathCountTotal, int deathCountStage, float timeTotal, float timeStage)
    {
        SetData(dataNum, savePoint, deathCountTotal, deathCountStage, timeTotal, timeStage);
    }
    public void SetData(int dataNum, int savePoint, int deathCountTotal, int deathCountStage, float timeTotal, float timeStage)
    {
        this.dataNum = dataNum;
        this.savePoint = savePoint;
        this.deathCountTotal = deathCountTotal;
        this.deathCountStage = deathCountStage;
        this.timeTotal = timeTotal;
        this.timeStage = timeStage;
    }
}

public class DataSave : MonoBehaviour
{
    public MenuUI uiScript;
    public string[] path = new string[3];
    public string path2;
    public string path3;

    public Text totalDeath;
    public Text savePoint;
    public Text totalTime;
    public Text bestSavePoint;

    public Image[] recordIcon = new Image[3];



    void Start()  
    {
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = GameManager.Instance.path[i];
        }
        BestSavePoint();
    }

    
    void Update()
    {
        
    }


    public void ShowDataRecord(int num)
    {
        Data data = new Data();
 

        if (File.Exists(path[num-1]))
        {
            for (int i = 0; i < recordIcon.Length; i++)
            {
                recordIcon[i].gameObject.SetActive(true);
            }

            string loadJson = File.ReadAllText(path[num - 1]);
            byte[] bytes = System.Convert.FromBase64String(loadJson);
            string reformat = System.Text.Encoding.UTF8.GetString(bytes);
            data = JsonUtility.FromJson<Data>(reformat);
            totalDeath.text = data.deathCountTotal.ToString();
            if (data.savePoint != 8)
                savePoint.text = data.savePoint.ToString();
            else
                savePoint.text = "CLEAR";
            totalTime.text = GameManager.Instance.Timer(data.timeTotal);
        }
        else
        {
            for(int i = 0;i<recordIcon.Length;i++)
            {
                recordIcon[i].gameObject.SetActive(false);
            }
            totalDeath.text = "";
            savePoint.text = "";
            totalTime.text = "EMPTY";
        }

    }
    public void GiveGameManagerInfo(int num)
    {
        Data data = new Data();
        if (File.Exists(path[num - 1]))
        {
            string loadJson = File.ReadAllText(path[num - 1]);
            byte[] bytes = System.Convert.FromBase64String(loadJson);
            string reformat = System.Text.Encoding.UTF8.GetString(bytes);
            data = JsonUtility.FromJson<Data>(reformat);
            GameManager.Instance.dataNum = data.dataNum;
            GameManager.Instance.savePointNow = data.savePoint;
            GameManager.Instance.deathCountTotal = data.deathCountTotal;
            GameManager.Instance.deathCountStage = data.deathCountStage;
            GameManager.Instance.time_total = data.timeTotal;
            GameManager.Instance.timeNow = data.timeStage;
        }
    }
    //새 데이터 생성
    public void JsonSave(int num)   
    {
        Data data = new Data();
        if(!File.Exists(path[num - 1]))
        {
            data.SetData(num, 0, 0, 0, 0, 0);
            string jdata = JsonConvert.SerializeObject(data);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
            string format = System.Convert.ToBase64String(bytes);
            File.WriteAllText(path[num-1], format);
        }
    }

    

    //데이터 존재하는지 체크
    public void CheckDataExist(int num)
    {

        uiScript.dataExist[num - 1] = File.Exists(path[num - 1]) ? true: false;

    }
    
    public void DestroyData(int num)
    {
        File.Delete(path[num - 1]);
    }


    private void BestSavePoint()
    {
        int BestSP=0;
        for(int i = 0;i<path.Length;i++)
        {
            
            if(File.Exists(path[i]))
            {
                Data data = new Data();
                string loadJson = File.ReadAllText(path[i]);
                byte[] bytes = System.Convert.FromBase64String(loadJson);
                string reformat = System.Text.Encoding.UTF8.GetString(bytes);
                data = JsonUtility.FromJson<Data>(reformat);
                if (data.savePoint > BestSP)
                    BestSP = data.savePoint;
            }
        }
        bestSavePoint.text = BestSP.ToString();


    }
}
