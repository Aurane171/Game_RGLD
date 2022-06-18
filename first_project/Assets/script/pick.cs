using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            
            inventory.instance.Addcoin(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
            
            
            //this.spriteRenderer.enabled = false;
            
            //Destroy(gameObject, ListSong[i].length);
        }

    }
}
