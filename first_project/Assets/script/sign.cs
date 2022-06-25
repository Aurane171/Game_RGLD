using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour
{

    private move_player move; 
    public Text interactUI;
   
    void Awake()
    {
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<move_player>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
        }
    }
}
