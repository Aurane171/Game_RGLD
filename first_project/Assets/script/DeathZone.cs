using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//algebra
public class DeathZone : MonoBehaviour
{
    //private Transform playerSpawn;
    private Animator Fade;

    private void Awake()
    {
        //playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        Fade = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
            playerheath.instance.TakeDamage(10);
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        Fade.SetTrigger("fadein");
        yield return new WaitForSeconds(1f);
       // collision.transform.position = playerSpawn.position;
    }
}
