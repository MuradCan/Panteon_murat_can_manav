using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour
{
    


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            
            Destroy(gameObject);
            
        }
    }

    private void Update()
    {
        Destroy(gameObject, 1);
    }
}
