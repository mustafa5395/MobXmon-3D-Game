using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    private BannerView banner;
    string AdsId;


    public GameObject Loading;
    public Slider Slider;


    public List<GameObject> LevelButtons;
    public List<GameObject> Canvas;
    public AudioSource ClickSound;
    public GameObject ExitCanvas;
    public Sprite soundOff;
    public Sprite soundOn;

    public List<GameObject> Informations;
    public GameObject InformationObject;


    int soundno;
    public int LevelNo;
    public int PageNo;
   private int PanelNo ;
    private void Start()
    {
     
      
           
           
    
            //RequestBanner();
        if (PlayerPrefs.GetInt("Level")>=0&& PlayerPrefs.GetInt("Level")<=11)
        {
            Canvas[0].SetActive(true);
        }
      if (PlayerPrefs.GetInt("Level") >= 11 && PlayerPrefs.GetInt("Level") <= 21)
        {
            Canvas[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") >= 21 && PlayerPrefs.GetInt("Level") <= 31)
        {
            Canvas[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") >= 31 && PlayerPrefs.GetInt("Level") <= 41)
        {
            Canvas[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") >= 41 && PlayerPrefs.GetInt("Level") <= 51)
        {
            Canvas[4].SetActive(true);
        }


        soundno = 0;
        PanelNo = 1;

    }
    public void LeftMenu(int no)
    {
        ClickSound.Play();
        if (no!=0)
        {
            for (int i = 0; i < Canvas.Count; i++)
            {
                Canvas[i].SetActive(false);
            }
            Canvas[no - 1].SetActive(true);
        }
        else
        {
            for (int i = 0; i < Canvas.Count; i++)
            {
                Canvas[i].SetActive(false);
            }
            Canvas[0].SetActive(true);
        }


    }

    public void RightMenu(int no)
    {
        ClickSound.Play();
        if (no!=4)
        {
            for (int i = 0; i < Canvas.Count; i++)
            {
                Canvas[i].SetActive(false);
            }
            Canvas[no + 1].SetActive(true);
        }
        else
        {
            for (int i = 0; i < Canvas.Count; i++)
            {
                Canvas[i].SetActive(false);
            }
            Canvas[4].SetActive(true);
        }
       
       

        
    }

    public void Sounds(GameObject Sound)
    {
        ClickSound.Play();
        if (soundno == 1)
        {
            ClickSound.Play();
            AudioListener.volume = 1;
            Sound.GetComponent<Image>().sprite = soundOn;

            soundno--;
          
        }
        else
        {
           
            AudioListener.volume = 0;
            Sound.GetComponent<Image>().sprite = soundOff;
            soundno++;
           

        }

    }
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

    public void Level(int Level)
    {
       
        ClickSound.Play();
        StartCoroutine(SahneYuklemeAsamasi(Level));
    }




    IEnumerator GameStart(int Value)
    {
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

    public void StartG()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator SahneYuklemeAsamasi(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        Loading.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Slider.value = progress;
            yield return null;

        }

    }

    public void Information()
    {
        InformationObject.SetActive(true);
    }
    public void InformationRight(int No)
    {
        if (No!=5)
        {

            for (int i = 0; i < Informations.Count; i++)
            {
                Informations[i].SetActive(false);
            }
            Informations[No + 1].SetActive(true);


        }
        else
        {

            for (int i = 0; i < Informations.Count; i++)
            {
                Informations[i].SetActive(false);
            }
            Informations[5].SetActive(true);
        }
    }

    public void InformationLeft(int No)
    {
        if (No != 0)
        {

            for (int i = 0; i < Informations.Count; i++)
            {
                Informations[i].SetActive(false);
            }
            Informations[No-1].SetActive(true);
        }
        else
        {

            for (int i = 0; i < Informations.Count; i++)
            {
                Informations[i].SetActive(false);
            }
            Informations[0].SetActive(true);
        }
    }

    public void InformationQuit()
    {
        InformationObject.SetActive(false);
        for (int i = 0; i < Informations.Count; i++)
        {
            Informations[i].SetActive(false);
        }
        Informations[0].SetActive(true);
    }
    //    void RequestBanner()
    //    {
    //#if UNITY_ANDROID
    //        AdsId = "ca-app-pub-3940256099942544/6300978111";
    //#elif UNITY_IPHONE
    //string AdsId="";
    //#else
    //        string AdsId = "NULL";
    //#endif

    //        banner = new BannerView(AdsId, AdSize.Banner, AdPosition.Bottom);




    //            banner.LoadAd(request1());



    //    }
    //AdRequest request1()
    //{
    //    return new AdRequest.Builder().Build();
    //}

    //void BannerClose()
    //{

    //    banner.Destroy();
    //}
}
