using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Target : MonoBehaviour
{

    private Animator animator;
    public float hp = 50f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
       hp -= amount;
        animator.SetTrigger("TakeDamage");
        if(hp <= 0f)
        {
            animator.SetTrigger("Death");
            Death();

        }
    }

    public void Death()
    {
        
        Destroy(gameObject);

        
    }

    private void Update()
    {
        DamageAnim();
    }

   private void DamageAnim()
    {
        if (hp > 0f && hp < 50f)
        {
            animator.SetTrigger("TakeDamage");
        }
        if (hp <= 0f)
        {
            animator.SetTrigger("Death");
            Death();
        }
    }





























}