using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterNearSFX : MonoBehaviour
{
 public AudioSource SpiderHiss;
 public AudioSource SpiderSFXAud;

    private Transform enemy; 



    // Start is called before the first frame update
    void Start()
    {
       
        SpiderHiss.enabled = false;
        SpiderSFXAud.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
       enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        EnemyDistance();
        
    }
   

    public void EnemyDistance()
    {
        float  distanceToEnemy = Vector3.Distance(transform.position, enemy.position);

        if (distanceToEnemy > 10)
        {
            SpiderHiss.enabled = true;


        }
        else
        {
            SpiderSFXAud.enabled = true;
        }
    }
   
}