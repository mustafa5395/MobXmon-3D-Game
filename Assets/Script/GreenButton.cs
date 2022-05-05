using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    public GameObject AddColor;
    public List<GameObject> GreenButon;
    public bool IsActive;
   



    IEnumerator SoundActive()
    {
        yield return new WaitForSeconds(GreenButon.Count * 0.5F);
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
    private void OnTriggerExit(Collider other)
    {
        SoundActive();
    }


}
