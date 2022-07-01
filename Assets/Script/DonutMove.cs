using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DonutMove : MonoBehaviour
{
    public float speed;
    public bool _left, _right;
    public static bool canMove;

    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        //if (maxpos > 0)
        //{
        //    if (transform.position.x <= maxpos)
        //    {
        //        transform.position += Vector3.right * Time.deltaTime * speed;
        //    }
        //}
        //if (maxpos < 0)
        //{
        //    if (transform.position.x >= maxpos)
        //    {
        //        transform.position += Vector3.right * Time.deltaTime * speed;
        //    }
        //}

        if (gameObject.transform.position.x >= -1f && _right)
        {
            canMove = true;
            StartCoroutine(callForwadR());
            StartCoroutine(callBackR());
        }
        

        

    }
    private IEnumerator callForwadR()
    {
        if (canMove)
        { 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        yield return new WaitForSeconds(2);
        StartCoroutine(callBackR());
        }
    }
    private IEnumerator callBackR()
    {
        if (gameObject.transform.position.x <= 1f && _right)
        {
            canMove = false;
            transform.Translate(Vector3.left * -speed * Time.deltaTime);
            yield return new WaitForSeconds(2);
        }
    }
}
