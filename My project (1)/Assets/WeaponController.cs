using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fireRate = 0.1f;
    public int magCap = 30;
    public int maxAmmoHeld = 180;

    //Changing Var
    bool _canFire;
    int _currentAmmoInMag;
    int _ammoBeingHeld;

    //Muzzle Flashing
    public Image muzzleFlashImage;
    public Sprite[] flashing;
    
    


    private void Start()
    {
        _currentAmmoInMag = magCap;
        _ammoBeingHeld = maxAmmoHeld;
        _canFire = true;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && _canFire && _currentAmmoInMag > 0) 
        {
            _canFire = false;
            _currentAmmoInMag--;
            StartCoroutine(FireWeapon());

        }
        else if(Input.GetKeyDown(KeyCode.R) && _currentAmmoInMag < magCap && _ammoBeingHeld > 0) 
        {
            int sumRequired = magCap - _currentAmmoInMag;
            if( sumRequired>= _ammoBeingHeld)
            {
                _currentAmmoInMag += _ammoBeingHeld;
                _ammoBeingHeld -= sumRequired;
            }
            else
            {
                _currentAmmoInMag = magCap;
                _ammoBeingHeld -= sumRequired;
            }
        }
    }

    IEnumerator FireWeapon()
    {
        StartCoroutine(MuzzleFlash());
        yield return new WaitForSeconds(fireRate);
        _canFire = true;
    }
    IEnumerator MuzzleFlash()
    {
        muzzleFlashImage.sprite = flashing[Random.Range(0, flashing.Length)];
        muzzleFlashImage.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        muzzleFlashImage = null;
        muzzleFlashImage.color = new Color(0, 0, 0, 0);
    }
}
