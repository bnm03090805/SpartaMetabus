using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QBGM
{
    public string Name {get; set; }
    public int ID { get; set; }
    public string[] Answers { get; set; }

}
public class QuizManager : MonoBehaviour
{
    public List<QBGM> BGMList = new List<QBGM>();
    [SerializeField] TextMeshProUGUI quizText;
    [SerializeField] GameObject answerUI;
    [SerializeField] GameObject wrongUI;

    public int Number { get; set; }
    public static QuizManager instance;

    public int Count;

    private void Awake()
    {
        instance = this;
        BGMList.Add(new QBGM { ID = 0, Name = "There's Something About Supertank", Answers = new string[] { "��Ʈ����2", "��Ʈ����","��Ʈ����2���" } });
        BGMList.Add(new QBGM { ID = 1, Name = "Reminiscence", Answers = new string[] { "����������" } });
        BGMList.Add(new QBGM { ID = 2, Name = "ChosunField", Answers = new string[] { "�Ż�" } });
        BGMList.Add(new QBGM { ID = 3, Name = "MapleLoginTheme", Answers = new string[] { "�����ý��丮","������" } });
        BGMList.Add(new QBGM { ID = 4, Name = "MaguMaguMainTheme", Answers = new string[] { "��������" } });
        Number = 0;
        Count = 3;
        UpdateNumber();
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
            UIManager.Instance.OpenUI(wrongUI);
            Invoke("InvokeCloseUI", 3f);
            Count--;
            if (Count == -1)
            {
                Number++;
                UpdateNumber();
                SoundManager.instance.StopBGM();
            }
            Debug.Log("Ʋ��");
        }
    }

    public void AnsewrEvent()
    {
        Debug.Log("����");
        UIManager.Instance.OpenUI(answerUI);
        Invoke("InvokeCloseUI", 3f);
        if(Number == SoundManager.instance.BGMList.Length-1)
        {
            Debug.Log("�Ϸ�");
        }
        else
        {
            Number++;
            UpdateNumber();
            SoundManager.instance.StopBGM();
        }
    }

    public void UpdateNumber()
    {
        quizText.text = (Number+1).ToString() + "�� ����";
        SoundManager.instance.ChangeBGM(BGMList[Number].ID);
    }

    public void InvokeCloseUI()
    {
        UIManager.Instance.CloseUI();
    }

}
