using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//algebra
public class CurrentSceneManager : MonoBehaviour
{

    public bool isPlayerPresentByDefault = false;
    public int coinsPickedUpInThisSceneCount;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de CurrentSceneManager dans la scene");
            return;
        }
        instance = this;
    }
}
