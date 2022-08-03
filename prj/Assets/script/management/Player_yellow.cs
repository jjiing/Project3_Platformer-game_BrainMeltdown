using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_yellow : Player
{
    
    void Start()
    {
        base.Start();
        gameObject.transform.position = currentSavePointPos + new Vector3(1, 0.5f, 0);

    }
    
    void Update()
    {
        if(!GameManager.Instance.isPaused 
            && !GameManager.Instance.isClear
            && !GameManager.Instance.isDead)
        { 
         Move(Input.GetAxisRaw("Horizontal"));
         Jump(Input.GetKeyDown(KeyCode.UpArrow));
         Sit(Input.GetKey(KeyCode.DownArrow));

         StateUpDown();
         MoveAnim();
         MoveSound(constant.PLAYER_Y_AUDIO_SOURCE);
        }


    }


    protected override void DieEffectColorSetting()
    {
        dieEffectSR.color = colorDic["yellow"];
    }
    protected override void LandingSoundAudioSetting()
    {
        audioNum = constant.PLAYER_Y_AUDIO_SOURCE;

    }

}
