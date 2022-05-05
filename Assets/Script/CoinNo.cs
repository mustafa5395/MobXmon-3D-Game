using System.Collections.Generic;
using UnityEngine;

public class CoinNo : MonoBehaviour
{
    public int No;
   public List<int> ListNo;


    private void Start()
    {
        if (PlayerPrefs.HasKey("Coin" + No))
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.gameObject.SetActive(true);
        }
    }
 
    
}
