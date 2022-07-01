using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rforce : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HorizontalObstacle")
        {
            EnemyScript.isDead = true;
            enemy.GetComponent<Rigidbody>().AddForce(-5, 2, 0, ForceMode.Impulse);
        }

    }
}
