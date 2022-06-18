using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour
{

    private move_player move; 
    public Text interactUI;
    //public GameObject Canvas; 
    
    void Awake()
    {
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<move_player>(); 
        //interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            //Canvas.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            //Canvas.SetActive(true);
        }
    
    }
}
