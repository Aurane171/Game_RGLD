using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gainhealth : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public AudioClip clip;
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);

            playerheath.instance.HealPlayer(15);
            //Source.PlayOneShot(Song);
            this.spriteRenderer.enabled = false;
            Destroy(gameObject);
        }
    }
}
