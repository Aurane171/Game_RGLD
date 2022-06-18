using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dam : MonoBehaviour
{
   public int damageOnCollision = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
            playerheath playerHealth = collision.transform.GetComponent<playerheath>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    
    }
}
