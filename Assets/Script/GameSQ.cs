using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSQ : MonoBehaviour
{

    public GameObject ExitCanvas;
    public AudioSource ClickSound;
    public void Home()
    {
        ClickSound.Play();
        StartCoroutine(GameStart(0));
    }

    public void Quit()
    {
        ClickSound.Play();
        StartCoroutine(GameStart(1));
    }


    IEnumerator GameStart(int Value)
    {
        if (!PlayerPrefs.HasKey("GameStart"))
        {
            PlayerPrefs.SetInt("GameStart", 1);
        }
        if (Value == 0)
        {
         
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene(1);
        }

        if (Value == 1)
        {
            yield return new WaitForSeconds(.5f);
            Application.Quit();
        }


    }

    public void Market()
    {
        SceneManager.LoadScene(2);
        ClickSound.Play();
    }
    public void YesQuit()
    {
        ClickSound.Play();
        ExitCanvas.SetActive(true);
    }
    public void NoQuit()
    {
        ClickSound.Play();
        ExitCanvas.SetActive(false);
    }
}
