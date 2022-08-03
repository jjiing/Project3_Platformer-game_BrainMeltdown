using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_purple : Player
{

    void Start()
    {
        base.Start();
        gameObject.transform.position = currentSavePointPos + new Vector3(-1, 0.5f, 0);

    }
    
    void Update()
    {
        if (!GameManager.Instance.isPaused 
            && !GameManager.Instance.isClear
            && !GameManager.Instance.isDead)
        {
            Move(Input.GetAxisRaw("Horizontal2"));
            Jump(Input.GetKeyDown(KeyCode.W));
            Sit(Input.GetKey(KeyCode.S));

            StateUpDown();
            MoveAnim();
            MoveSound(constant.PLAYER_P_AUDIO_SOURCE);
        }
    }

   
   
    protected override void DieEffectColorSetting()
    {
        dieEffectSR.color = colorDic["purple"];
    }
    protected override void LandingSoundAudioSetting()
    {
        audioNum = constant.PLAYER_P_AUDIO_SOURCE;

    }

}
