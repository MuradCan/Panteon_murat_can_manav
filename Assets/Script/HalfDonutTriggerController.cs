using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutTriggerController : MonoBehaviour
{
    public GameObject movingStick;
    private bool isPassed;
    public bool _left, _right;
    

    

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isPassed)
        {
            isPassed = true;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !isPassed )
        {
            isPassed = true;
        }
    }

    void FixedUpdate()
    {

        if (_right)
        {
            if (isPassed)
            {
                if (movingStick.transform.position.x >= -1.7f)
                {
                    movingStick.transform.Translate(Vector3.left * 15 * Time.deltaTime);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                StartCoroutine(comeBackR());
            }
        }
        if (_left)
        {
            if (isPassed)
            {
                if (movingStick.transform.position.x <= 1.7f)
                {
                    movingStick.transform.Translate(Vector3.left * 15 * Time.deltaTime);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                StartCoroutine(comeBackL());
            }
        }
    }

    IEnumerator comeBackR()
    {
        yield return new WaitForSeconds(2);
        
        if (movingStick.transform.position.x <= 14.3f)
        {
            movingStick.transform.Translate(Vector3.right * 15 * Time.deltaTime);
            isPassed = false;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        } 
    }

    IEnumerator comeBackL()
    {
        yield return new WaitForSeconds(2);

        if (movingStick.transform.position.x >= -14.3f)
        {
            movingStick.transform.Translate(Vector3.right * 15 * Time.deltaTime);
            isPassed = false;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
