using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public TextMeshProUGUI talkText;
    public bool isDaeSangHyukOn = false;
    public bool isRiding = false;
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    { 
        UIManager.Instance.UIStack.Clear();
        if(scene.name == "FlappyBirdMiniGameScene")
        {
            Time.timeScale = 0f;
        }
        if(scene.name == "BGMQuizScene")
        {
            SoundManager.instance.StopBGM();
        }
    }
    
}