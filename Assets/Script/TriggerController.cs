using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject horizontalObstacle;
    
    public void Start()
    {
        
    }
    public void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            horizontalObstacle.GetComponent<MoveDirection>().enabled=true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            horizontalObstacle.GetComponent<MoveDirection>().enabled = true;
        }
    }
}
