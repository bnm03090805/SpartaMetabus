using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameZone : MonoBehaviour
{
    [SerializeField] private GameObject gotoMinigameUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager.Instance.OpenUI(gotoMinigameUI);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIManager.Instance.CloseUI();
    }
}
