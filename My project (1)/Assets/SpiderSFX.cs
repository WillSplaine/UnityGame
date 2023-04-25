using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSFX : MonoBehaviour
{
    
   
    

   public  AudioSource SpiderHiss;
   public  AudioSource SpiderSFXAud;
    
    
    void Start()
    {
       

        SpiderHiss.enabled = false;
        SpiderSFXAud.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void SpiderSounds()
    {
        

        SpiderSFXAud.enabled = true;
        SpiderHiss.enabled = true;
    }
    
}