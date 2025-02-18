using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartBtn : MonoBehaviour
{
    PlaneGameManager planeGameManager = null;

    private void Start()
    {
        planeGameManager = PlaneGameManager.Instance;
    }

    public void GameStart()
    {
        planeGameManager.GameStart();
    }
}
