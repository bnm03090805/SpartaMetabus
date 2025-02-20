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
        ChatUI = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        text = GameObject.Find("Canvas").transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        chat = GetComponent<NPCChat>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("z") && isEnter == true)
        {
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
