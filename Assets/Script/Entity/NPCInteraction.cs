using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactKey;
    private void Start()
    {
        interactKey = GameObject.Find("NpcCanvas").transform.GetChild(0).gameObject;
        //interactKey.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
        //Debug.Log(interactKey.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        interactKey.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactKey.SetActive(false);
    }
}
