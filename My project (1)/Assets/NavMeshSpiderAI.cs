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

    public PlayerHP playerHP;

    public AudioSource SpiderHiss;
    public AudioSource SpiderSFXAud;

    public float stoppingDistance = 5;


    // Start is called before the first frame update
    private void Start()
    {
        playerHP = GameObject.Find("Player").GetComponent<PlayerHP>();
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
            SpiderSFXAud.Play();
        }
        else animator.SetBool("Walk", false);
        SpiderHiss.Play();
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
            StartCoroutine("DamagePlayer", 5f);
            
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

        
        Attacking();
    }
    public void DistanceToTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
    }

    public IEnumerator DamagePlayer()
    {
        playerHP.playerDamage();
         yield return null;
    }
    
    
    
}
