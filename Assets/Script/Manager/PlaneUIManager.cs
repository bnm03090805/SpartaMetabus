using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaneUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameExitText;
    public TextMeshProUGUI gameDescription;
    public TextMeshProUGUI gameStart;
    public TextMeshProUGUI bestScoreText;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }
        if (gameExitText == null)
        {
            Debug.LogError("GameExitText is null");
            return;
        }
        restartText.gameObject.SetActive(false);
        gameExitText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        gameExitText.gameObject.SetActive(true);
    }

    public void SetStart()
    {
        restartText.gameObject.SetActive(false);
        gameExitText.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(false);
        gameStart.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int score)
    {
        bestScoreText.text = "BestScore : " + score.ToString();
    }
}