using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QBGM
{
    public string Name { get; set; }
    public int ID { get; set; }
    public string[] Answers { get; set; }

}
public class QuizManager : MonoBehaviour
{
    public List<QBGM> BGMList = new List<QBGM>();
    [SerializeField] TextMeshProUGUI quizText;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] GameObject answerUI;
    [SerializeField] GameObject wrongUI;
    [SerializeField] GameObject resutUI;
    [SerializeField] TextMeshProUGUI corretCountText;
    [SerializeField] TextMeshProUGUI wrongCountText;
    [SerializeField] TextMeshProUGUI bestCorrectCountText;

    public int Number { get; set; }
    public static QuizManager instance;

    public int Count;
    public int corretCount;
    public int wrongCount;
    public int BestCorrectCount { get; set; }
    private const string BestCorrectCountKey = "BestCorrectCount";

    private void Awake()
    {
        instance = this;
        BGMList.Add(new QBGM { ID = 0, Name = "There's Something About Supertank", Answers = new string[] { "포트리스2", "포트리스", "포트리스2블루" } });
        BGMList.Add(new QBGM { ID = 1, Name = "Reminiscence", Answers = new string[] { "테일즈위버" } });
        BGMList.Add(new QBGM { ID = 2, Name = "ChosunField", Answers = new string[] { "거상" } });
        BGMList.Add(new QBGM { ID = 3, Name = "MapleLoginTheme", Answers = new string[] { "메이플스토리", "메이플" } });
        BGMList.Add(new QBGM { ID = 4, Name = "MaguMaguMainTheme", Answers = new string[] { "마구마구" } });
        Number = 0;
        Count = 3;
        corretCount = 0;
        wrongCount = 0;
        BestCorrectCount = PlayerPrefs.GetInt(BestCorrectCountKey, 0);
        UpdateNumber();
        UpdateCount();
    }

    public void AnswerChcek(string answer)
    {
        var chcek = BGMList[Number].Answers.ToList().Exists(x => x == answer);
        if (chcek)
        {
            AnsewrEvent();
        }
        else
        {
            WrongEvent();
        }
    }

    public void AnsewrEvent()
    {
        Debug.Log("정답");
        corretCount++;
        if (Number == SoundManager.instance.BGMList.Length - 1)
        {
            Debug.Log("완료");
            Result();
        }
        else
        {
            UIManager.Instance.OpenUI(answerUI);
            Invoke("InvokeCloseUI", 1.5f);
            Number++;
            UpdateNumber();
            SoundManager.instance.StopBGM();
        }
    }

    public void UpdateNumber()
    {
        quizText.text = (Number + 1).ToString() + "번 문제";
        SoundManager.instance.ChangeBGM(BGMList[Number].ID);
        Count = 3;
        UpdateCount();
    }

    public void UpdateCount()
    {
        countText.text = "남은횟수 : " + Count.ToString();
    }

    public void InvokeCloseUI()
    {
        UIManager.Instance.CloseUI();
    }

    public void Result()
    {
        if (corretCount != 0)
        {
            GameManager.Instance.LeaderBoard(corretCount, GameManager.Instance.rankGame2);
        }

        if (BestCorrectCount < corretCount)
        {
            Debug.Log("최고점수갱신");
            BestCorrectCount = corretCount;
            PlayerPrefs.SetInt(BestCorrectCountKey, BestCorrectCount);
        }
        corretCountText.text = "맞춘 문제 : " + corretCount.ToString();
        wrongCountText.text = "틀린 문제 : " + wrongCount.ToString();
        bestCorrectCountText.text = "베스트스코어 : " + BestCorrectCount.ToString();
        UIManager.Instance.OpenUI(resutUI);

    }

    public void WrongEvent()
    {
        Count--;
        if (Count == 0)
        {
            wrongCount++;
            if (Number == SoundManager.instance.BGMList.Length - 1)
            {
                Result();
            }
            else
            {
                Number++;
                UpdateNumber();
                SoundManager.instance.StopBGM();
                Count = 3;
                UIManager.Instance.OpenUI(wrongUI);
                Invoke("InvokeCloseUI", 1.5f);
            }

        }
        else
        {
            UIManager.Instance.OpenUI(wrongUI);
            Invoke("InvokeCloseUI", 1.5f);
            UpdateCount();
        }
        Debug.Log("틀림");
    }

}
