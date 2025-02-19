using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactKey;
    private void Start()
    {
        interactKey = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        Debug.Log(interactKey.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}
