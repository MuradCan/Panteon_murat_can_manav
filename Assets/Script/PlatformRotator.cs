using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    
    public float rotationSpeed,x,eX;
    float yForce, zForce;
    public bool Left, Right;

    // Update is called once per frame
    void FixedUpdate()
    {
        eX = Random.Range(1f, 3.0f);
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
           
            if(Right)
                col.gameObject.transform.Translate(x * Time.deltaTime, yForce * Time.deltaTime, zForce * Time.deltaTime);
            if (Left)
                col.gameObject.transform.Translate(-x * Time.deltaTime, yForce * Time.deltaTime, zForce * Time.deltaTime);
        }

        else if (col.gameObject.tag == "Enemy")
        {

            if (Right)
                col.gameObject.transform.Translate(eX * Time.deltaTime, yForce * Time.deltaTime, zForce * Time.deltaTime);
            if (Left)
                col.gameObject.transform.Translate(-eX * Time.deltaTime, yForce * Time.deltaTime, zForce * Time.deltaTime);

        }
        else
            col.gameObject.transform.Translate(0, 0, 0);
    }

}
