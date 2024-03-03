using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    
    void Start()
    {
       offset =  transform.position -player.position;
    }

   
    void Update()
    {
        Vector3 desiredPosition = new Vector3( transform.position.x, transform.position.y,offset.z + player.position.z );
        transform.position = desiredPosition;
    }
}
