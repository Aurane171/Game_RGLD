
using UnityEngine;

using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] objects;

    public static DontDestroy instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de DontDestroy dans la sc�ne");
            return;
        }
        instance = this;
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
       
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

   
}
