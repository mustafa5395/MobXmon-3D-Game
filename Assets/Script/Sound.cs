using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;
    int soundno;
    public AudioSource ClickSound;

    void Start()
    {
        soundno = 1;
        if (PlayerPrefs.GetInt("Sound") == 0)
        {     
            AudioListener.volume = 1;
            gameObject.GetComponent<Image>().sprite = On;
        }
        if (PlayerPrefs.GetInt("Sound") == 1)   
        {
            AudioListener.volume = 0;
            gameObject.GetComponent<Image>().sprite = Off;
        }



    }

    public void Sounds()
    {
        ClickSound.Play();
        if (PlayerPrefs.GetInt("Sound")==0)
        {
           
           
            AudioListener.volume = 0;
            gameObject.GetComponent<Image>().sprite = Off;
            PlayerPrefs.SetInt("Sound", 1);
           // Debug.Log(PlayerPrefs.GetInt("Sound") + "0 olmasý lazým");
        }
       else
        {
          
            AudioListener.volume = 1;
            gameObject.GetComponent<Image>().sprite = On;
            PlayerPrefs.SetInt("Sound", 0);
            //Debug.Log(PlayerPrefs.GetInt("Sound") +" "+ "1 olmasý lazým");
        }

    }



}
