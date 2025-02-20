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
    public static GameManager Instance
    {
        get { return gameManager; }
    }
    private void Awake()
    {
        gameManager = this;
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

    public void NPCTalkEvent()
    {

    }
    
}