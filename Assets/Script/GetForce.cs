using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetForce : MonoBehaviour
{
    public float forceSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            EnemyScript.isDead = true;
            
            other.gameObject.GetComponent<Rigidbody>().AddForce(forceSpeed, 0,0 , ForceMode.Impulse);

        }
        if (other.gameObject.tag == "L")
        {
            other.gameObject.GetComponentInParent<Rigidbody>().AddForce(-forceSpeed*2, 0,0, ForceMode.Impulse);
        }
        if (other.gameObject.tag == "R")
        {
            other.gameObject.GetComponentInParent<Rigidbody>().AddForce(forceSpeed*2, 0,0, ForceMode.Impulse);
        }

    }
}
