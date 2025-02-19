using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerInput : MonoBehaviour
{
    
    [SerializeField] TMP_InputField answerInput;
    public string answer = null;

    private void Awake()
    {
        answer = answerInput.GetComponent<TMP_InputField>().text;
    }

    private void Update()
    {
        if (answer.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            InputAnswer();
        }
    }

    public void InputAnswer()
    {
        answer = answerInput.text;
        Debug.Log(answer);
        QuizManager.instance.AnswerChcek(answer);
    }
}
