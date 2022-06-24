using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadLevel : MonoBehaviour
{
    public string sceneName;
   public string currentsceneName;
   public Animator fadeSystem;


    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (currentsceneName == "Level_4")
        {
            if (collision.CompareTag("Player")&&inventory.instance.coin_count>=10)
            {

                StartCoroutine(loadNextScene());
                int nbcoin = inventory.instance.coin_count;
                inventory.instance.RemoveCoins(nbcoin); 

            }
        }
        if (currentsceneName == "Level_5")
        {
            if (collision.CompareTag("Player") && inventory.instance.coin_count >= 20)
            {

                StartCoroutine(loadNextScene());
                int nbcoin = inventory.instance.coin_count;
                inventory.instance.RemoveCoins(nbcoin);

            }
        }
        else if(collision.CompareTag("Player"))
        { 
            StartCoroutine(loadNextScene());
            int nbcoin = inventory.instance.coin_count;
            inventory.instance.RemoveCoins(nbcoin);
        }

    }
        
        
    

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("fadein");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName); 
       
    }
}
