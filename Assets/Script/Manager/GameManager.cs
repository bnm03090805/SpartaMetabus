using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

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
        if(scene.name == "MiniGameScene")
        {
            Time.timeScale = 0f;
        }
    }

    
}