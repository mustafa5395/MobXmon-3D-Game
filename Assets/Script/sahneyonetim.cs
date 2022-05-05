using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sahneyonetim : MonoBehaviour
{
    public GameObject LoadingEkrani;
    public Slider yuklemeslider;
      

   public  void SahneYukle(int Levelid)
    {
        StartCoroutine(SahneYuklemeAsamasi(Levelid));

    }


    IEnumerator SahneYuklemeAsamasi(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingEkrani.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yuklemeslider.value = progress;
            yield return null;

        }

    }

}
