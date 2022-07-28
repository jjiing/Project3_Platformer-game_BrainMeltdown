using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    public bool box1active;
    public bool[] dataExist = new bool[3];
    public int dataNum;
    public Image[] checkImage = new Image[3];
    public DataSave dataSaveScript;

    public Image box1;
    public Image box2;
    public Image normalbox;


    private void Start()
    {
        dataNum = 1;
        box1active = true;


    }

    private void Update()
    {
        MenuManage();
        ActivateDataboxImangeOn(dataNum);
        DataManage();
    }
    private void MenuManage()
    {
        if (box1active)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            { if (dataNum < 3) dataNum++; }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            { if (dataNum > 1) dataNum--; }
        }

    }
    private void ActivateDataboxImangeOn(int num)
    {
        for (int i = 0; i < checkImage.Length; i++)
            checkImage[i].gameObject.SetActive(false);

        checkImage[num - 1].gameObject.SetActive(true);
    }

    private void DataManage()
    {
        
        dataSaveScript.CheckDataExist(dataNum);
        dataSaveScript.ShowDataRecord(dataNum);
        if (box1active)
        {
            if (dataExist[dataNum - 1])
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dataSaveScript.GiveGameManagerInfo(dataNum);
                    if (GameManager.Instance.savePointNow < 4)
                        SceneManager.LoadScene("stage1");
                    else
                        SceneManager.LoadScene("stage2");
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return)) box2active(true);

            }
            if(Input.GetKeyDown(KeyCode.Delete))
            {
                dataSaveScript.DestroyData(dataNum);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                dataSaveScript.JsonSave(dataNum);
                GameManager.Instance.dataNum = dataNum;
                SceneManager.LoadScene("stage1");
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                box2active(false);
            }
        }
    }
    private void box2active(bool bool_)
    {
        box1active = !bool_;
        box1.gameObject.SetActive(!bool_);
        box2.gameObject.SetActive(bool_);
        normalbox.gameObject.SetActive(bool_);
    }
}
