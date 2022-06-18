using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//algebra
public class inventory : MonoBehaviour
{
    public int coin_count;
    public Text coin_text; 

    public static inventory instance; 

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    public void Addcoin(int count)
    {
        coin_count += count;
        coin_text.text = coin_count.ToString();
    }

    public void RemoveCoins(int count)
    {
        coin_count -= count;
        coin_text.text = coin_count.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.instance.Addcoin(10); 
        }
    }
}
