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

    private int currentScore = 0;
    PlaneUIManager planeUIManager;

    public PlaneUIManager PlaneUIManager
    {
        get { return planeUIManager; }
    }
    private void Awake()
    {
        gameManager = this;
        planeUIManager = FindObjectOfType<PlaneUIManager>();
    }

    private void Start()
    {
        planeUIManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        planeUIManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        planeUIManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }

}