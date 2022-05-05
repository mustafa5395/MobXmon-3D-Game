using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameKontrol : MonoBehaviour
{
    private InterstitialAd  InterVideoTransitionAds;
    public string AdsVideoId;


   
    public GameObject Loading;
    public Slider LoadScene;


    [Header("Teleport")]
    public List<GameObject> TeleportIn;
    public List<GameObject> TeleportEx;

    [Header("Paneller")]
    public GameObject MiddlePanel;
    public GameObject WinPanel;
    public GameObject StopButton;
    public AudioSource ClickSound;

    public List<GameObject> Characters;
    int DeatValue;
    int CompleteValue;
    int RefreshValue;

    public int MiddleNo;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("DeatValue"))
        {
            PlayerPrefs.SetInt("DeatValue", 1);
           
        }

        if (!PlayerPrefs.HasKey("CompleteValue"))
        {
            PlayerPrefs.SetInt("CompleteValue", 1);
        }

        if (!PlayerPrefs.HasKey("RefreshValue"))
        {
            PlayerPrefs.SetInt("RefreshValue", 1);
        }
        RequestVideoTransition();
        Debug.Log(PlayerPrefs.GetInt("RefreshValue"));
        Debug.Log(PlayerPrefs.GetInt("CompleteValue"));
        Debug.Log(PlayerPrefs.GetInt("DeatValue"));
        Time.timeScale = 1;
        MiddleNo = 0;
        LevelPlayer();
       
        for (int i = 0; i < Characters.Count; i++)
        {
            Characters[i].SetActive(false);
        }
        Characters[PlayerPrefs.GetInt("Characters")].SetActive(true);

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 1;
          
        }
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 0;
         
        }

    }
    public void GameOver()
    {
        if (PlayerPrefs.GetInt("CompleteValue") == 3 || PlayerPrefs.GetInt("DeatValue") == 3 || PlayerPrefs.GetInt("RefreshValue") == 3)
        {
            Debug.Log("reklm");
            GameOverVideoAds();
            PlayerPrefs.SetInt("CompleteValue", 1);
            PlayerPrefs.SetInt("DeatValue", 1);
            PlayerPrefs.SetInt("RefreshValue", 1);
        }
        else
        {
            PlayerPrefs.SetInt("DeatValue", PlayerPrefs.GetInt("DeatValue") + 1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      

    }
   
    public void Win()
    {
        if (PlayerPrefs.GetInt("CompleteValue")==3|| PlayerPrefs.GetInt("DeatValue") == 3|| PlayerPrefs.GetInt("RefreshValue") == 3)
        {
            Debug.Log("reklm");
            GameOverVideoAds();
            PlayerPrefs.SetInt("CompleteValue", 1);
            PlayerPrefs.SetInt("DeatValue", 1);
            PlayerPrefs.SetInt("RefreshValue", 1);
        }
        else
        {
            PlayerPrefs.SetInt("CompleteValue", PlayerPrefs.GetInt("CompleteValue") + 1);
        }
       
        CompleteValue++;
        Scene scene = SceneManager.GetActiveScene();


        if (!PlayerPrefs.HasKey("LevelNo"))
        {
            PlayerPrefs.SetInt("LevelNo", scene.buildIndex + 1);
            Debug.Log(PlayerPrefs.GetInt("LevelNo") + "else");
        }
        else
        {
           
            
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("LevelNo"))
            {
                PlayerPrefs.SetInt("LevelNo", scene.buildIndex + 1);

                Debug.Log(PlayerPrefs.GetInt("LevelNo") + "bölüm");
            }
            else
            {
                PlayerPrefs.SetInt("LevelNo", PlayerPrefs.GetInt("LevelNo"));
            }
        }

        WinPanel.SetActive(true);
        StopButton.SetActive(false);
        MiddlePanel.SetActive(false);
       
      
       
    }

    public void Menu()
    {
        ClickSound.Play();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        MiddlePanel.SetActive(false);
    }
    public void NextLevel()
    {
        ClickSound.Play();
    
        if (SceneManager.GetActiveScene().buildIndex==52)
        {
            StartCoroutine(SahneYuklemeAsamasi(1));
        }
        else
        {
            StartCoroutine(SahneYuklemeAsamasi(SceneManager.GetActiveScene().buildIndex + 1));
        }
       //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    IEnumerator SahneYuklemeAsamasi(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        Loading.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadScene.value = progress;
            yield return null;

        }

    }
    public void Again()
    {
        if (PlayerPrefs.GetInt("CompleteValue") == 3 || PlayerPrefs.GetInt("DeatValue") == 3 || PlayerPrefs.GetInt("RefreshValue") == 3)
        {
            Debug.Log("reklm");
            GameOverVideoAds();
            PlayerPrefs.SetInt("CompleteValue", 1);
            PlayerPrefs.SetInt("DeatValue", 1);
            PlayerPrefs.SetInt("RefreshValue", 1);
        }
        else
        {
            PlayerPrefs.SetInt("RefreshValue", PlayerPrefs.GetInt("RefreshValue") + 1);
        }
        ClickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
     
    }

    public void Settings()
    {
        ClickSound.Play();
        MiddlePanel.SetActive(true);
        Time.timeScale = 0;
        StopButton.SetActive(false);
        MiddleNo = 1;
    }

    public void SettingsQuit()
    {
        ClickSound.Play();
        MiddlePanel.SetActive(false);
        Time.timeScale = 1;
        StopButton.SetActive(true);
        MiddleNo = 0;
    }



    public void GameOverVideoAds()
    {
        if (InterVideoTransitionAds.IsLoaded())
        {
            InterVideoTransitionAds.Show();
        }
        else
        {
            RequestVideoTransition();
        }
    }
    void RequestVideoTransition()
    {
#if UNITY_ANDROID
        AdsVideoId = "ca-app-pub-9344611202433050/7312890640";
#elif UNITY_IPHONE
string AdsVideoId="";
#else
         AdsVideoId = "NULL";
#endif
        InterVideoTransitionAds = new InterstitialAd(AdsVideoId);

        InterVideoTransitionAds.OnAdLoaded += yuklendimi;
        InterVideoTransitionAds.OnAdFailedToLoad += yuklemedesorunvar;
        InterVideoTransitionAds.OnAdOpening += acildi;
        InterVideoTransitionAds.OnAdClosed += kapatildi;
        InterVideoTransitionAds.OnAdLeavingApplication += arkaplanaatildimi;


        InterVideoTransitionAds = new InterstitialAd(AdsVideoId);
        AdRequest request = new AdRequest.Builder().Build();
        InterVideoTransitionAds.LoadAd(request);
    }

    public void yuklendimi(object sender, EventArgs args)
    {



    }
    public void yuklemedesorunvar(object sender, AdFailedToLoadEventArgs args)
    {

        RequestVideoTransition();

    }
    public void acildi(object sender, EventArgs args)
    {


    }
    public void kapatildi(object sender, EventArgs args)
    {

        RequestVideoTransition();
    }
    public void arkaplanaatildimi(object sender, EventArgs args)
    {


    }


    void LevelPlayer()
    {


        //if (SceneManager.GetActiveScene().buildIndex < PlayerPrefs.GetInt("LevelNo"))
        //{
        //    for (int i = 0; i < Coins.Count; i++)
        //    {
        //        Coins[i].SetActive(false);
        //    }
        //}
        //if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("LevelNo"))
        //{
        //    for (int i = 0; i < Coins.Count; i++)
        //    {
        //        Coins[i].SetActive(true);
        //    }
        //}
    }
   


}
