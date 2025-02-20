using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlaneGameManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject scoreUI;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    int bestScore = 0;
    public int BestScore { get=>  bestScore;}
    private const string BestScoreKey = "BestScore";

    static PlaneGameManager planeGameManager;

    public static PlaneGameManager Instance
    {
        get { return planeGameManager; }
    }

    private int currentScore = 0;
    //PlaneUIManager planeUIManager;

    private void Awake()
    {
        planeGameManager = this;
        //planeUIManager = FindObjectOfType<PlaneUIManager>();
    }

    private void Start()
    {
        UpdateScoreUI(0);
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        UIManager.Instance.OpenUI(startMenu);
    }
    private void Update()
    {
        Debug.Log(bestScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        if (currentScore != 0)
        {
            GameManager.Instance.LeaderBoard(currentScore, GameManager.Instance.rankGame1);
            scoreData data = new scoreData(GameManager.Instance.rankGame1);
            SaveSystem.Save(data, "save_001");

        }
        UpdateScore();
        bestScoreText.text = "BestScore : " + bestScore.ToString();
        SetRestart(bestScore);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScoreUI(currentScore);
        Debug.Log("Score: " + currentScore);
    }

    public void GameStart()
    {
        Time.timeScale = 1.0F;
        SetStart();
    }

    void UpdateScore()
    {
        if (currentScore > bestScore)
        {
            Debug.Log("최고점수경신");
            bestScore = currentScore;

            PlayerPrefs.SetInt(BestScoreKey, currentScore);
            UpdateBestScore(BestScore);
        }
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int score)
    {
        bestScoreText.text = "BestScore : " + score.ToString();
    }

    public void SetRestart(int score)
    {
        UIManager.Instance.CloseUI();
        UIManager.Instance.OpenUI(gameOverUI);
    }

    public void SetStart()
    {
        UIManager.Instance.CloseUI();
        UIManager.Instance.OpenUI(scoreUI);
    }
}
