using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCChat : MonoBehaviour
{
    private int step;
    public string[] strings;
    bool inputKey = false;

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
        if (!ChatUI.activeSelf)
        {
            step = 0;
            UIManager.Instance.OpenUI(ChatUI);
            text.text = strings[step];
        }
        else
        {
            text.text = strings[step];
                

            if (step == strings.Length-1)
            {
                UIManager.Instance.CloseUI();
                step = 0;
                return;
            }
        }
        
    }
}
