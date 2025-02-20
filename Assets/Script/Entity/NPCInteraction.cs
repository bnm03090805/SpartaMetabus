using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactKey;
    //[SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private GameObject ChatUI;
    [SerializeField] private TextMeshProUGUI text;
    NPCChat chat;
    public bool isEnter = false;

    private void Start()
    {
        interactKey = GameObject.Find("NpcCanvas").transform.GetChild(0).gameObject;
        chat = GetComponent<NPCChat>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("z") && isEnter == true)
        {
            Debug.Log("Z키입력 감지");
            chat.ChatEvent(ChatUI, text);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        interactKey.SetActive(true);
        isEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactKey.SetActive(false);
        isEnter = false;
    }
}
