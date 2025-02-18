using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneGameManager : MonoBehaviour
{
    static PlaneGameManager planeGameManager;

    public static PlaneGameManager Instance
    {
        get { return planeGameManager; }
    }

    private int currentScore = 0;
    PlaneUIManager planeUIManager;

    private void Awake()
    {
        planeGameManager = this;
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

    public void GameStart()
    {
        Time.timeScale = 1.0F;
        planeUIManager.SetStart();
    }
}
