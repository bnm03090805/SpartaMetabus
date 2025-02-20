using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardPopupUI : MonoBehaviour
{
    [SerializeField] private GameObject leaderBoardUI;

    public void OpenLeaderBoardUI()
    {
        UIManager.Instance.OpenUI(leaderBoardUI);
    }
}
