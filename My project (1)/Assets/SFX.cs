using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource footstepSound;
    public AudioSource smgFiring;

    public Gun gun;

    private void Start()
    {
        footstepSound.enabled = false;  
        smgFiring.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
        }

        if (Input.GetMouseButton(0) && gun.currentAmmoInMag > 0) {
            smgFiring.enabled = true;

        }
        else
        {
            smgFiring.enabled = false;
        }



    }



}
