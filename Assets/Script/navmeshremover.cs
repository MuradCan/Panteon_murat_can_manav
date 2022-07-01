using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshremover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<EnemyScript>().enabled = false;
        }
    }
}
