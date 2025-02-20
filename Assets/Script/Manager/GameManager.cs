using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

[Serializable]
public class scoreData
{
    public List<int> score;

    public scoreData(List<int> score)
    {
        this.score = score;
    }
}

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

        scoreData data = new scoreData(rank);

        SaveSystem.Save(data, "save_001");
    }
    
}

public static class SaveSystem
{
    private static string SavePath => Application.persistentDataPath + "/saves/";

    public static void Save(scoreData data, string SaveFileName)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }

        string saveJson = JsonUtility.ToJson(data);
        string saveFilePath = SavePath + SaveFileName + ".json";
        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("세이브성공");
    }

    public static scoreData Load(string saveFilename)
    {
        string saveFilePath = SavePath + saveFilename + ".json";

        if (!File.Exists(saveFilePath)) 
        {
            Debug.Log("세이브파일 없음");

            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        scoreData data = JsonUtility.FromJson<scoreData>(saveFile);

        return data;
    }
}