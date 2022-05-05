using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int No;
    void Start()
    {
        if (No==1)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            
                if (PlayerPrefs.GetInt("Level") >= No)
                {
                    GetComponent<Button>().interactable = true;
                }
            
          
        }
        
    }
}
