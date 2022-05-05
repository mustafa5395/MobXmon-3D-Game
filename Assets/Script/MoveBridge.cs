using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
  
    public GameObject BridgePoint;
    public GameObject BridgePoint2;
    public float Distance;
    public bool IsMove;
    float TimeV;
    bool BridgePosition;

    private void Start()
    {
        BridgePosition = false;
        TimeV = Time.time;
     //   gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, BridgePoint.transform.position, (Time.time - TimeV) * Distance);
       
       
    }
    private void Update()
    {
        if (!BridgePosition)
        {
            transform.position = Vector3.Lerp(transform.position, BridgePoint.transform.position, (Time.time - TimeV) * Distance);
            BridgePosition = true;
        }
    }
    private void FixedUpdate()
    {
      
    }

}
