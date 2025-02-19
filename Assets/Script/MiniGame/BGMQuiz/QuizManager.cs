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


    public static QuizManager instance;

    private void Awake()
    {
        instance = this;
        BGMList.Add(
            new QBGM { ID = 1, Name = "There's Something About Supertank", Answers = new string[] { "��Ʈ����2", "��Ʈ����"} }
            );

        Debug.Log("����Ŵ���");
        Debug.Log(BGMList[0].Name);
    }

    public void AnswerChcek(string answer)
    {
        var chcek = BGMList[0].Answers.ToList().Exists(x => x == answer);
        if (chcek)
        {
            AnsewrEvent();
        }
        else
        {
            Debug.Log("Ʋ��");
        }
    }

    public void AnsewrEvent()
    {
        Debug.Log("����");
    }




}
