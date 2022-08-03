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
    public float volume;


    private void Awake()
    {
        base.Awake();
        volume = 0.5f;

    }
    private void Update()
    {
        SetVolume(volume);
    }

    public void SetVolume(float volume)
    {
        for (int i = 0; i <= 1; i++)
        {
            audioSources[i].volume = volume;
        }


        for (int i = 2; i <= 3; i++)
            audioSources[i].volume = volume/10;

    }


    public void PlaySE(string _name, int audioSourceNum)
    {
        for(int i = 0;i< soundClass.Length;i++)
        {
            if(_name == soundClass[i].name)
            {
                audioSources[audioSourceNum].clip = soundClass[i].clip;
                audioSources[audioSourceNum].Play();

                    
            }
        }
    }
    public void StopSE(int audioSourceNum)
    {
         audioSources[audioSourceNum].Stop();
    }

   
    

}
