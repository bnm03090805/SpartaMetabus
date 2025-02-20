using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI talkText;
    public bool isDaeSangHyukOn = false;
    public bool isRiding = false;
    public static GameManager Instance;

    public List<int> rankGame1 = new List<int>();
    public List<int> rankGame2 = new List<int>();

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

    public void LeaderBoard(int score, List<int> rank)
    {
        if (rank.Count >= 1)
        {
            rank.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));
            if (rank.Exists(x => x <= score))
            {
                rank.Insert(rank.FindIndex(x => x <= score), score);
            }
            else
            {
                rank.Add(score);
            }
        }
        else
        {
            rank.Add(score);
        }

    }
    
}