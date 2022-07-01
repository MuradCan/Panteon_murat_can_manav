using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spareMover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Random.Range(0.5f, -0.5f), Random.Range(0.5f,-0.5f),1) * Time.deltaTime * speed;
    }
}
