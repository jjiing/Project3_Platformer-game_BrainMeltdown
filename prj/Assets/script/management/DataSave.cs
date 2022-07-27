using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class Data
{
    public int savePoint;

    public int deathCountTotal;
    public int deathCountStage;

    public float timeTotal;
    public float timeStage;

    public Data(int savePoint, int deathCountTotal, int deathCountStage, float timeTotal, float timeStage)
    {
        SetData(savePoint, deathCountTotal, deathCountStage, timeTotal, timeStage);
    }
    public void SetData(int savePoint, int deathCountTotal, int deathCountStage, float timeTotal, float timeStage)
    {
        this.savePoint = savePoint;
        this.deathCountTotal = deathCountTotal;
        this.deathCountStage = deathCountStage;
        this.timeTotal = timeTotal;
        this.timeStage = timeStage;
    }
}

public class DataSave : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void onClick()
    {
        Debug.Log("온클릭실행");
    }
    public void NewData()
    {
        Debug.Log("실행");
        Data data = new Data(0, 0, 0, 0, 0);
        string jdata= JsonConvert.SerializeObject(data);

        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        //string format = System.Convert.ToBase64String(bytes);
        
        File.WriteAllText(Application.dataPath + "/DATA1.json", jdata);

    }
}
