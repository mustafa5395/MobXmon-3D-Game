using UnityEngine;

public class Isinlan : MonoBehaviour
{
    public int SiraNo;
    public bool Durum;
    public bool GelenDurum;

    

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
  



}
