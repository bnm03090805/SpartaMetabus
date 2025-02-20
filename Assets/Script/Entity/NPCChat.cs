using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCChat : MonoBehaviour
{
    private int step;
    public string[] strings;
    public string[] strings2;
    public bool inputKey = false;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputKey = true;
            step++;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            inputKey = false;
        }
    }
    public void ChatEvent(GameObject ChatUI,TextMeshProUGUI text)
    {
        if (!GameManager.Instance.isDaeSangHyukOn)
        {
            if (!ChatUI.activeSelf)
            {
                step = 0;
                UIManager.Instance.OpenUI(ChatUI);
                text.text = strings[step];
            }
            else
            {
                text.text = strings[step];

                if (step == strings.Length - 1)
                {
                    SoundManager.instance.StopBGM();
                    SoundManager.instance.ChangeLNDBGM();
                    SoundManager.instance.PlayBGM();
                    UIManager.Instance.CloseUI();
                    step = 0;
                    GameManager.Instance.isDaeSangHyukOn = true;
                    return;
                }
            }
        }
        else
        {
            if (!ChatUI.activeSelf)
            {
                step = 0;
                UIManager.Instance.OpenUI(ChatUI);
                text.text = strings2[step];
            }
            else
            {
                text.text = strings2[step];

                if (step == strings2.Length - 1)
                {
                    SoundManager.instance.StopBGM();
                    SoundManager.instance.ChangeERBGM();
                    SoundManager.instance.PlayBGM();
                    UIManager.Instance.CloseUI();
                    step = 0;
                    GameManager.Instance.isDaeSangHyukOn = false;
                    return;
                }
            }
        }
        
        
    }
}
