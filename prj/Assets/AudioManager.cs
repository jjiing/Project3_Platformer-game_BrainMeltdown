using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 데이터 직렬화
public class Sound
{
    public string name; //곡의 이름
    public AudioClip clip; // 곡
}
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource[] audioSources;
    public Sound[] soundClass; 


    private void Awake()
    {
        base.Awake();
    }

    public void SetVolume(float volume)
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = volume;
        }
    }

    //audioSourceNum 
    // BGM : 1
    // Effect : 2
    // yellow : 3
    // purple : 4
    public void PlaySE(string _name, int audioSourceNum)
    {
        for(int i = 0;i< soundClass.Length;i++)
        {
            if(_name == soundClass[i].name)
            {
                audioSources[audioSourceNum-1].clip = soundClass[i].clip;
                audioSources[audioSourceNum-1].Play();

            }
        }
    }

  
}
