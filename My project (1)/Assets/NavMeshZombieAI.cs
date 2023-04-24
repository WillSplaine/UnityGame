using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshZombieAI : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Transform target;
    private Animator animator;

    public float stoppingDistance = 3;


    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        Reference();
        target = GameObject.FindGameObjectWithTag("Player").transform;
       // NavMeshHit closestHit;

       // if (NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f, NavMesh.AllAreas))//
         //   gameObject.transform.position = closestHit.position;//
       // else
         //   Debug.LogError("Could not find position on NavMesh!");//
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
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
   
    void Update()
    {
     float distanceToTarget = Vector3.Distance(transform.position, target.position);
        

            GoToTarget();
            transform.LookAt(target);
            


            Attacking();
        
    }
}
