using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ParticleSystemJobs;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    public ParticleSystem particleEffect;
    private NavMeshAgent nma;
    public Animator animator;
    public bool stick;
    public float randomSpeed,temp;
    public static bool isDead;  

    private void Awake()
    {
        randomSpeed = Random.Range(4.2f,5f);
        nma = GetComponent<NavMeshAgent>();
        temp = randomSpeed;
        
    }

    private void Update()
    {
        nma.destination = movePositionTransform.position;
        nma.speed = randomSpeed;
        animator.SetBool("dead", stick);

    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "EndPos")
        {
            particleEffect.Play();
            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag=="HD_stick")
        {
            
            stick = true;
            isDead = true;
            randomSpeed = 0;
            
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            StartCoroutine(TryAgain());
            
        }

    }

    public IEnumerator TryAgain()
    {
        
        yield return new WaitForSeconds(1.3f);
        
        randomSpeed = temp;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        StartCoroutine(Beklee());
    }

    public IEnumerator Beklee()
    {
        yield return new WaitForSeconds(0.5f);
        stick = false;
        isDead = false;
        gameObject.transform.position = new Vector3(Random.Range(-7, 7), 1.4f, -16);
        
    }
}
