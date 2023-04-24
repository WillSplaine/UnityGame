using System;
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    //Ammo Settings

    public int magCap = 30;
    private int maxAmmo = 420;

    public int currentAmmoInMag;
    public int ammoBeingHeld;

    bool canFire;


    public float reloadTime = 1f;
   

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

   

    private float NextTimeToFire = 0f;

    private void Start()
    {
        currentAmmoInMag = magCap;
        ammoBeingHeld = maxAmmo;
        canFire = true;
    }
    
    private void Update()
    {
       
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire && canFire && currentAmmoInMag > 0)
        {
            NextTimeToFire = Time.time + 1f / fireRate;
            canFire = false;
            Shoot();
        }
         if (Input.GetKeyDown(KeyCode.R) && currentAmmoInMag < magCap && ammoBeingHeld > 0)
        {
            int sumRequired = magCap - currentAmmoInMag;
            if (sumRequired >= ammoBeingHeld)
            {
                currentAmmoInMag += ammoBeingHeld;
                ammoBeingHeld -= sumRequired;
            }
            else
            {
                currentAmmoInMag = magCap;
                ammoBeingHeld -= sumRequired;
            }
        }




        void Shoot()
        {
            currentAmmoInMag--;
            muzzleFlash.Play();
            canFire = true;
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }

        }


    }
}

   
