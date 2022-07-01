using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Boy;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if(!PlayerScript.gameEnd)
            transform.position = new Vector3(offset.x, Boy.position.y+offset.y, Boy.position.z+ offset.z);
            
        if (PlayerScript.gameEnd)
        { 
            transform.position = new Vector3(0, 6.78f, 155.87f);
            transform.eulerAngles = new Vector3 (0,0,0);
        }
    }
}
