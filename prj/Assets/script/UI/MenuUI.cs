using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    [Header("Data Save")]
    public DataSave dataSaveScript;
    [SerializeField] int dataNum;
    [SerializeField] bool box1active;
    public bool[] dataExist = new bool[3];

    [Header("Activate button")]
    [SerializeField] Image box1;
    [SerializeField] Image box2;
    [SerializeField] Image normalbox;
    [SerializeField] Image[] checkImage = new Image[3];


    private void Start()
    {
        if (AudioManager.Instance.audioSources[constant.BACKGROUND_AUDIO_SOURCE].clip.name != "MAINBGM")
            AudioManager.Instance.PlaySE("mainBGM", constant.BACKGROUND_AUDIO_SOURCE);
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
            if (Input.GetKeyDown(KeyCode.DownArrow) && dataNum < 3)
            {
                dataNum++;
                AudioManager.Instance.PlaySE("button", constant.EFFECT_AUDIO_SOURCE);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && dataNum > 1)
            {
                dataNum--;
                AudioManager.Instance.PlaySE("button", constant.EFFECT_AUDIO_SOURCE);
            }


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main");
            }
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
        //데이터 있는지 체크 후 기록 보여주기
        dataExist[dataNum-1] = dataSaveScript.CheckDataExist(dataNum);
        dataSaveScript.ShowDataRecord(dataNum);


        
        switch (box1active)
        {
            //첫번째 창 활성화
            case true:

                //데이터 있을 경우
                if (dataExist[dataNum - 1])
                {
                    //데이터 있을 때 게임 시작
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        AudioManager.Instance.PlaySE("gameStartClick", constant.EFFECT_AUDIO_SOURCE);
                        dataSaveScript.GiveGameManagerInfo(dataNum);
                        if (GameManager.Instance.savePointNow < 4)
                            SceneManager.LoadScene("stage1");
                        else
                            SceneManager.LoadScene("stage2");
                    }
                    //데이터 삭제
                    if (Input.GetKeyDown(KeyCode.Delete))
                    {
                        AudioManager.Instance.PlaySE("click", constant.EFFECT_AUDIO_SOURCE);
                        dataSaveScript.DestroyData(dataNum);
                        dataSaveScript.BestSavePoint();
                    }

                }
                //데이터 없을 경우
                else
                {
                    //데이터 없을경우 난이도 설정창으로
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        AudioManager.Instance.PlaySE("click", constant.EFFECT_AUDIO_SOURCE);
                        box2active(true);
                    }

                }
                break;


            //두번째 창활성화
            case false:
                
                //새로운 데이터로 시작
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    AudioManager.Instance.PlaySE("gameStartClick", constant.EFFECT_AUDIO_SOURCE);
                    dataSaveScript.JsonSave(dataNum);
                    dataSaveScript.GiveGameManagerInfo(dataNum);
                    GameManager.Instance.dataNum = dataNum;
                    SceneManager.LoadScene("stage1");
                }
                //다시 첫번째 창으로
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    AudioManager.Instance.PlaySE("click", constant.EFFECT_AUDIO_SOURCE);
                    box2active(false);
                }
                break;
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
