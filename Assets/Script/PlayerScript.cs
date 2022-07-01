using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f, maxSpeed = 5f, jumpingForce = 5f, speedTemp;
    public Animator animator;
    public Rigidbody rb;
    public GameObject Character;
    bool isGrounded, frontDie, backDie, dance;
    public static bool gameEnd;
    public SensitiveJoystick sj;
    // Start is called before the first frame update
    void Start()
    {
        speedTemp = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpingForce);
        }

    }

        void FixedUpdate()
    {
        
        float h = CnInputManager.GetAxis("Horizontal");

        if (h > 0)
        {
            transform.Translate(h * speed * Time.deltaTime, 0, 0);
        }

        if (h < 0)
        {
            transform.Translate(h * speed * Time.deltaTime, 0, 0);
        }

        transform.Translate(0, 0,  speed * Time.deltaTime);
        /*
        float v = Input.GetAxis("Vertical");
        if (v > 0)
        {
            transform.Translate(0, 0, v * speed * Time.deltaTime);
        }

        if (v < 0)
        {
            transform.Translate(0, 0, v * speed * Time.deltaTime);
        }
        
        

      
        float v = Input.GetAxis("Vertical");
    
        Vector3 movDir;
        movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movDir.x * (speed - 2) * Time.deltaTime, 0, movDir.z * speed * Time.deltaTime);
        

        animator.SetFloat("Speed", Mathf.Abs(h));
        animator.SetFloat("Speed", Mathf.Abs(v));
        */
        animator.SetBool("isJumping", !isGrounded);
        
        
       

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "h_Obstacle")
        {
            isGrounded = true;
        }
        else
            isGrounded = false;

        if(collision.gameObject.tag=="Enemy")
        {
            rb.AddForce(0, 0, -2, ForceMode.Impulse);
        }

        if(collision.gameObject.tag=="_Finish")
        {
            collision.gameObject.SetActive(false);
            speed = 0;
            dance = true;
            animator.SetBool("dance", dance);
            gameEnd=true;
            transform.eulerAngles = new Vector3(0, -180, 0);
            sj.GetComponent<SensitiveJoystick>().enabled = false;
            sj.GetComponent<EmptyGraphic>().enabled = false;
            
            
        }

        if(collision.gameObject.tag== "StaticObstacle")
        {
            backDie=true;
            speed = 0;
            transform.position = new Vector3(transform.position.x, -0.39f, transform.position.z);
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            rb.isKinematic=true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            animator.SetBool("backDie", backDie);
            StartCoroutine(TryAgain());
        }

        if(collision.gameObject.tag=="HD_stick")
        {
            frontDie = true;
            speed = 0;
            transform.position = new Vector3(transform.position.x, -0.39f, transform.position.z);
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            rb.isKinematic = true;
            animator.SetBool("frontDie", frontDie);
            StartCoroutine(TryAgain2());
        }

    }

    public IEnumerator TryAgain()
    {
        yield return new WaitForSeconds(1.499f);
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        rb.isKinematic = false;
        speed = speedTemp;
        animator.SetBool("backDie", !backDie);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        transform.position = new Vector3(0,0.05f,-16);

    }
    public IEnumerator TryAgain2()
    {
        yield return new WaitForSeconds(1.52f);
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        rb.isKinematic = false;
        speed = speedTemp;
        animator.SetBool("frontDie", !frontDie);
        transform.position = new Vector3(0, 0.05f, -16);

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "h_Obstacle")
        {
            isGrounded = false;
        }
        else
            isGrounded = true;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "h_Obstacle")
        {
            isGrounded = true;
        }
        else
            isGrounded = false;

       
    }



}
