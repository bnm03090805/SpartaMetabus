using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource m_AudioSource;
    public AudioClip m_Clip;
    public AudioClip[] BGMList;

    private float masterVol;
    private float bgmVol;

    public float MasterVol => masterVol;
    public float BgmVol => bgmVol;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        masterVol = 1.0f;
        bgmVol = 1.0f;

        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_Clip;
        m_AudioSource.volume = bgmVol * masterVol;

    }

    private void Start()
    {
        m_AudioSource.Play();
    }

    public void ChangeMasterVolume(float figure)
    {
        masterVol = figure;
        m_AudioSource.volume = bgmVol * masterVol;
       
    }

    public void ChangeBGMVolume(float figure)
    {
        bgmVol = figure;
        m_AudioSource.volume = bgmVol * masterVol;
    }

    public void StopBGM()
    {
        m_AudioSource.Stop();
    }

    public void ChangeBGM(int num)
    {
        m_AudioSource.clip = BGMList[num];
    }

    public void PlayBGM()
    {
        m_AudioSource.Play();
    }

    public void ChangeERBGM()
    {
        m_AudioSource.clip = m_Clip;
    }

}
