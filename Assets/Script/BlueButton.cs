using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    public List<GameObject> Objeler;
    public List<GameObject> HedefOjeler;
    public GameObject Color;
    public float Mesafe;
    public bool NegPoz;
    public bool Child;

 
    private void OnTriggerEnter(Collider other)
    {
       
            if (other.transform.gameObject.CompareTag("Player"))
            {
            Triger(transform.gameObject);
            }
        
    }
    IEnumerator Triger(GameObject game)
    {
        yield return new WaitForSeconds(0.2f);
        game.GetComponent<BoxCollider>().isTrigger = false; ;
    }


}
