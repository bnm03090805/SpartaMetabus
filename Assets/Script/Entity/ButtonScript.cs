using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayBridMiniGame()
    {
        SceneManager.LoadScene("FlappyBirdMiniGameScene");
    }

    public void GotoMinigameSclcetScene()
    {
        SceneManager.LoadScene("MiniGameSecletScene");
    }

    public void PlayQiuz()
    {
        SceneManager.LoadScene("BGMQuizScene");
    }

    public void CloseUI()
    {
        UIManager.Instance.CloseUI();
    }

    public void ExitBGMQiuzButton()
    {
        SoundManager.instance.ChangeERBGM();
        SoundManager.instance.PlayBGM();
        SceneManager.LoadScene("MiniGameSecletScene");
    }

}
