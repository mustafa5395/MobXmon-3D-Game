using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text TotalCoin;
    void Start()
    {
        if (PlayerPrefs.HasKey("TotalCoin"))
        {
            TotalCoin.text = PlayerPrefs.GetInt("TotalCoin").ToString();
        }
    }

 
}
