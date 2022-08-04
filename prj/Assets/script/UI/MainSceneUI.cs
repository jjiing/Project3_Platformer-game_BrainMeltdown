using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    int check;
    public Image[] checkImage = new Image[4];
    public Slider sound;

    private void Start()
    {
        check = 1;
        if(AudioManager.Instance.audioSources[constant.BACKGROUND_AUDIO_SOURCE].clip ==null)
            AudioManager.Instance.PlaySE("mainBGM", constant.BACKGROUND_AUDIO_SOURCE);

    }

    private void Update()
    {
        MainManage();           //키보드로 checknum관리
        CheckImangeOn(check);   //버튼유아이 활성화관리
        ButtonManage(check);    //실제동작
    }
    private void MainManage()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { 
            if (check < 4) check++;
            AudioManager.Instance.PlaySE("button", constant.EFFECT_AUDIO_SOURCE);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        { 
            if (check > 1) check--;
            AudioManager.Instance.PlaySE("button", constant.EFFECT_AUDIO_SOURCE);
        }
    }
    private void CheckImangeOn(int num)
    {
        for (int i = 0; i < checkImage.Length; i++)
            checkImage[i].gameObject.SetActive(false);

        checkImage[num - 1].gameObject.SetActive(true);
    }
    private void ButtonManage(int num)
    {
        switch (num)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    AudioManager.Instance.PlaySE("click", constant.EFFECT_AUDIO_SOURCE);
                    SceneManager.LoadScene("Menu");
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Return))
                    ExitGame();
                break;
            case 3:
                SoundControl();
                break;
        }
    }    
    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    private void SoundControl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            sound.value += 0.1f;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            sound.value -= 0.1f;
        AudioManager.Instance.volume = sound.value;
    }

    


}
