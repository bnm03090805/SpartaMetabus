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

    public void PlayMiniGame()
    {
        UIManager.Instance.CloseUI();
        UIManager.Instance.UIStack.Clear();
        SceneManager.LoadScene("MiniGameScene");
    }

}
