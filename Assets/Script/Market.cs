using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public List<GameObject> Panels;
    public List<GameObject> MarketInfo;
    public List<GameObject> Select;
    public List<Text> SelectText;

    public int MarketCoin;
    public Text CoinText;
    public AudioSource CoinSound;


    public AudioSource ClickSound;
    void Start()
    {
        Prints();

    
    }

    public void PanelRight()
    {
        ClickSound.Play();
        Panels[1].SetActive(true);
        Panels[0].SetActive(false);

    }
    public void PanelLeft()
    {
        ClickSound.Play();
        Panels[0].SetActive(true);
        Panels[1].SetActive(false);
    }

    public void Info(int Value)
    {
        Debug.Log(PlayerPrefs.GetInt("TotalCoin"));
        if (PlayerPrefs.GetInt("TotalCoin") >= MarketCoin)
        {

            if (Value == 0)
            {
                CoinSound.Play();
                PlayerPrefs.SetInt("Info", 1);

                MarketInfo[0].SetActive(false);
                Select[0].SetActive(true);

                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - 220);
                CoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
            }

            if (Value == 1)
            {
                CoinSound.Play();
                PlayerPrefs.SetInt("Info1", 2);
                MarketInfo[1].SetActive(false);
                Select[1].SetActive(true);

                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - 220);
                CoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
            }
            if (Value == 2)
            {

                CoinSound.Play();
                PlayerPrefs.SetInt("Info2", 3);
                MarketInfo[2].SetActive(false);
                Select[2].SetActive(true);

                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - 220);
                CoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
            }

            if (Value == 3)
            {

                CoinSound.Play();
                PlayerPrefs.SetInt("Info3", 4);
                MarketInfo[3].SetActive(false);
                Select[3].SetActive(true);

                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - 220);
                CoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
            }
            if (Value == 4)
            {
                CoinSound.Play();
                PlayerPrefs.SetInt("Info4", 5);
                MarketInfo[4].SetActive(false);
                Select[4].SetActive(true);

                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - 220);
                CoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
            }
            if (Value == 5)
            {

                CoinSound.Play();
                PlayerPrefs.SetInt("Info5", 6);
                MarketInfo[5].SetActive(false);
                Select[5].SetActive(true);

                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - 220);
                CoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
            }
        }

    }

    public void Selects(int Value)
    {
        ClickSound.Play();
        for (int i = 0; i < SelectText.Count; i++)
        {
            SelectText[i].text = "SELECT";
        }
        if (Value == 0)
        {
            PlayerPrefs.SetInt("Select1", 0);
            PlayerPrefs.SetInt("Select2", 0);
            PlayerPrefs.SetInt("Select3", 0);
            PlayerPrefs.SetInt("Select4", 0);
            PlayerPrefs.SetInt("Select5", 0);

            PlayerPrefs.SetInt("Characters", Value);
            PlayerPrefs.SetInt("Select", 7);
            SelectText[0].text = "SELECTED";
           
        }
        if (Value == 1)
        {
           
            PlayerPrefs.SetInt("Select", 8);
            PlayerPrefs.SetInt("Select2", 0);
            PlayerPrefs.SetInt("Select3", 0);
            PlayerPrefs.SetInt("Select4", 0);
            PlayerPrefs.SetInt("Select5", 0);

            PlayerPrefs.SetInt("Characters", Value);
            PlayerPrefs.SetInt("Select1", 2);
            SelectText[1].text = "SELECTED";

        }
        if (Value == 2)
        {
           
            PlayerPrefs.SetInt("Select1", 0);
            PlayerPrefs.SetInt("Select", 8);
            PlayerPrefs.SetInt("Select3", 0);
            PlayerPrefs.SetInt("Select4", 0);
            PlayerPrefs.SetInt("Select5", 0);

            PlayerPrefs.SetInt("Characters", Value);
            PlayerPrefs.SetInt("Select2", 3);
            SelectText[2].text = "SELECTED";
        }
        if (Value == 3)
        {
            
            PlayerPrefs.SetInt("Select1", 0);
            PlayerPrefs.SetInt("Select", 8);
            PlayerPrefs.SetInt("Select2", 0);
            PlayerPrefs.SetInt("Select4", 0);
            PlayerPrefs.SetInt("Select5", 0);


            PlayerPrefs.SetInt("Characters", Value);
            PlayerPrefs.SetInt("Select3", 4);
            SelectText[3].text = "SELECTED";
        }
        if (Value == 4)
        {
            
            PlayerPrefs.SetInt("Select1", 0);
            PlayerPrefs.SetInt("Select", 8);
            PlayerPrefs.SetInt("Select2", 0);
            PlayerPrefs.SetInt("Select3", 0);
            PlayerPrefs.SetInt("Select5", 0);

            PlayerPrefs.SetInt("Characters", Value);
            PlayerPrefs.SetInt("Select4", 5);
            SelectText[4].text = "SELECTED";
        }
        if (Value == 5)
        {
           
            PlayerPrefs.SetInt("Select1", 0);
            PlayerPrefs.SetInt("Select", 8);
            PlayerPrefs.SetInt("Select2", 0);
            PlayerPrefs.SetInt("Select4", 0);
            PlayerPrefs.SetInt("Select3", 0);


            PlayerPrefs.SetInt("Characters", Value);
            PlayerPrefs.SetInt("Select5", 6);
            SelectText[5].text = "SELECTED";
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
        ClickSound.Play();
    }
    void Prints()
    {
        if (PlayerPrefs.GetInt("Select") == 7)
        {
            SelectText[0].text = "SELECTED";
        }
        if (PlayerPrefs.GetInt("Select") == 8)
        {
            SelectText[0].text = "SELECT";
        }


        if (PlayerPrefs.GetInt("Select1") == 2)
        {
            SelectText[1].text = "SELECTED";
        }
        else
        {
            SelectText[1].text = "SELECT";
        }

        if (PlayerPrefs.GetInt("Select2") == 3)
        {
            SelectText[2].text = "SELECTED";
        }
        else
        {
            SelectText[2].text = "SELECT";
        }

        if (PlayerPrefs.GetInt("Select3") == 4)
        {
            SelectText[3].text = "SELECTED";
        }
        else
        {
            SelectText[3].text = "SELECT";
        }

        if (PlayerPrefs.GetInt("Select4") == 5)
        {
            SelectText[4].text = "SELECTED";
        }
        else
        {
            SelectText[4].text = "SELECT";
        }

        if (PlayerPrefs.GetInt("Select5") == 6)
        {
            SelectText[5].text = "SELECTED";
        }
        else
        {
            SelectText[5].text = "SELECT";
        }



        if (PlayerPrefs.GetInt("Info") == 1)
        {
            MarketInfo[0].SetActive(false);
            Select[0].SetActive(true);
        }

        if (PlayerPrefs.GetInt("Info1") == 2)
        {
            MarketInfo[1].SetActive(false);
            Select[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Info2") == 3)
        {
            MarketInfo[2].SetActive(false);
            Select[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Info3") == 4)
        {
            MarketInfo[3].SetActive(false);
            Select[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Info4") == 5)
        {
            MarketInfo[4].SetActive(false);
            Select[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Info5") == 6)
        {
            MarketInfo[5].SetActive(false);
            Select[5].SetActive(true);
        }
    }
}
