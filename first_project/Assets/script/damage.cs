using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int damageOnCollision = 5;
    private bool found = false;
    public SpriteRenderer spriteRenderer;
    public AudioClip clip;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);

            if (!found)
            {
                this.spriteRenderer.enabled = true ;
                found = true;
            }
            if (found)
            {
                playerheath playerHealth = collision.transform.GetComponent<playerheath>();
                playerHealth.TakeDamage(damageOnCollision);
            }
        }
    }
}
