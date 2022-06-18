using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//algebra

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de GameOverManager dans la scene");
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
       if (CurrentSceneManager.instance.isPlayerPresentByDefault)
       {
            DontDestroy.instance.RemoveFromDontDestroyOnLoad();
       }
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        //CurrentSceneManager.instance.coinsPickedUpInThisSceneCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerheath.instance.Respawn();
        gameOverUI.SetActive(false);
    }

   

    public void QuitButton()
    {
        Application.Quit();
    }
}
