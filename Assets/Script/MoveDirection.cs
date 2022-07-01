using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public float maxpos,speed;

    void Start()
    {
    
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (maxpos > 0)
        {
            if (transform.position.x <= maxpos)
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
        if (maxpos < 0)
        {
            if (transform.position.x >= maxpos)
            {
                transform.position += Vector3.right * Time.deltaTime * -speed;
            }
        }
    }

    
}
