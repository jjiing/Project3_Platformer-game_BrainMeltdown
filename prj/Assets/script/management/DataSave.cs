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
    
    private string[] path = new string[3];
    
    [Header("UI")]
    public MenuUI uiScript;
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

   


    public void ShowDataRecord(int num)
    {
        //������ �� ��� �����ֱ�
        Data data = new Data();
        data = JasonLoad(num-1,data);
        totalDeath.text = data.deathCountTotal.ToString();
        totalTime.text = GameManager.Instance.Timer(data.timeTotal);
        if (data.savePoint != 8)
            savePoint.text = data.savePoint.ToString();
        else
            savePoint.text = "CLEAR";


        //��� ������ �̹��� ����
        RecordIconManage(num);

    }
    protected void RecordIconManage(int num)
    {
        //������ ���� ��� ������ ���ְ� ��Ƽ ����
        if (!File.Exists(path[num - 1]))
        {
            for (int i = 0; i < recordIcon.Length; i++)
            {
                recordIcon[i].gameObject.SetActive(false);
            }
            totalDeath.text = "";
            savePoint.text = "";
            totalTime.text = "EMPTY";
        }
        else
        {
            for (int i = 0; i < recordIcon.Length; i++)
            {
                recordIcon[i].gameObject.SetActive(true);

            }
        }
    }
    public void GiveGameManagerInfo(int num)
    {
        Data data = new Data();
        data = JasonLoad(num - 1, data);
        
        GameManager.Instance.dataNum = data.dataNum;
        GameManager.Instance.savePointNow = data.savePoint;
        GameManager.Instance.deathCountTotal = data.deathCountTotal;
        GameManager.Instance.deathCountStage = data.deathCountStage;
        GameManager.Instance.time_total = data.timeTotal;
        GameManager.Instance.timeNow = data.timeStage;
        
    }
    //�� ������ ����
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

    

    //������ �����ϴ��� üũ
    public bool CheckDataExist(int num)
    {
       return File.Exists(path[num - 1]) ? true: false;
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
            Data data = new Data();
            data = JasonLoad(i, data);
            if (data.savePoint > BestSP)
                BestSP = data.savePoint;
        }
        bestSavePoint.text = BestSP.ToString();

    }

    protected Data JasonLoad(int num, Data data)
    {
        if (File.Exists(path[num]))
        {
            string loadJson = File.ReadAllText(path[num]);
            byte[] bytes = System.Convert.FromBase64String(loadJson);
            string reformat = System.Text.Encoding.UTF8.GetString(bytes);
            data = JsonUtility.FromJson<Data>(reformat);
        }
        return data;
    }
}
