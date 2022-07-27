using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;


public class MenuUI : MonoBehaviour
{
    public int dataNum;
    public Image[] checkImage = new Image[3];
    public DataSave dataSaveScript;
    private void Start()
    {
        dataNum = 1;
        
    }

    private void Update()
    {
        MenuManage();
        CheckImangeOn(dataNum);
        DataManage();
    }
    private void MenuManage()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { if (dataNum < 3) dataNum++; }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        { if (dataNum > 1) dataNum--; }

    }
    private void CheckImangeOn(int num)
    {
        for (int i = 0; i < checkImage.Length; i++)
            checkImage[i].gameObject.SetActive(false);

        checkImage[num - 1].gameObject.SetActive(true);
    }
    private void DataManage()
    {
        if(dataNum ==1 && Input.GetKeyDown(KeyCode.Return))
        {
            dataSaveScript.NewData();
        }
    }
}
