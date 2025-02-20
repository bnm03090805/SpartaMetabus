using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public List<TextMeshProUGUI> rank1 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> rank2 = new List<TextMeshProUGUI>();
    public List<GameObject> rankList1 = new List<GameObject>();
    public List<GameObject> rankList2 = new List<GameObject>();

    private void Start()
    {
        LeaderBoardWrite();
    }

    public void LeaderBoardWrite()
    {
        if (GameManager.Instance.rankGame1.Count>=1)
        {
            for (int i = 0; i <= rank1.Count- 1 && i <= GameManager.Instance.rankGame1.Count-1; i++)
            {
                if (!rankList1[i].activeSelf)
                {
                    rankList1 [i].SetActive(true);
                }
                rank1[i].text = GameManager.Instance.rankGame1[i].ToString() + " Á¡";
            }
        }

        if (GameManager.Instance.rankGame2.Count >= 1)
        {
            for (int i = 0; i <= rank2.Count-1 && i <= GameManager.Instance.rankGame2.Count-1; i++)
            {
                if (!rankList2[i].activeSelf)
                {
                    rankList2[i].SetActive(true);
                }
                rank2[i].text = GameManager.Instance.rankGame2[i].ToString() +" Á¡";
            }
        }
    }
}
