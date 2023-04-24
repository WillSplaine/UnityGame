using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshSpiderAI : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Transform target;
    private Animator animator;
    private Transform targetAim;
    public AudioSource spiderNoise;
    public AudioSource spiderHiss;

    public float stoppingDistance = 5;


    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        Reference();
        target = GameObject.FindGameObjectWithTag("PlayerC").transform;
        targetAim = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    private void GoToTarget()
    {
        agent.SetDestination(target.position);
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget >= stoppingDistance)
        {
            animator.SetBool("Walk", true);
        }
        else animator.SetBool("Walk", false);
    }

    private void Reference()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame

    private void Attacking()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= stoppingDistance)
        {
            animator.SetBool("Attack2", true);
         
        }
        else
        {
            animator.SetBool("Attack2", false);
            
        }
    }
   
    void Update()
    {
     float distanceToTarget = Vector3.Distance(transform.position, target.position);
        

            GoToTarget();
            transform.LookAt(targetAim);
            transform.Rotate(0, 180, 0);

            SFX();
            Attacking();
        
        
            
}
             

   private void SFX()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget  >= 12f)
        {
            spiderHiss.enabled = false;
            spiderNoise.enabled = true;
        }
        else
        {
            spiderHiss.enabled = true;
            spiderNoise.enabled = false;
        }
    }
}
