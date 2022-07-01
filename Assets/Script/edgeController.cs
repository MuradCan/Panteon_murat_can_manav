using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class edgeController : MonoBehaviour
{
    public bool Left, Right;
    public GameObject edgeParticle;
    public float xforce;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(edgeParticle, other.gameObject.transform.position, other.gameObject.transform.rotation);
            
            
            other.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            other.gameObject.GetComponent<EnemyScript>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = true;
            other.gameObject.GetComponent<Rigidbody>().velocity=Vector3.zero;
            StartCoroutine(Bekle());
            other.gameObject.transform.position = new Vector3(Random.Range(-7, 7), 1.4f, -16);

        }
        if (other.gameObject.tag == "Player")
        {
            Instantiate(edgeParticle, other.gameObject.transform.position, other.gameObject.transform.rotation);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(Bekle());
            other.gameObject.transform.position = new Vector3(Random.Range(-7, 7), 1.4f, -16);

        }
    }

    IEnumerator Bekle()
    {
        yield return new WaitForSeconds(0.2f);
        
    }
}
