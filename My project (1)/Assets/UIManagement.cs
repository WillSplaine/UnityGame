using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Text magAmmo;
    public Text ammoHeld;
    public Text roundNumber;
    
    /// grab ammo stats from gun Script
    public Gun gun;
    
    
    /// takes WaveNumber from wavespawner Script
    public RoundSpawner roundSpawner;

    // Update is called once per frame
    void Update()
    {
        magAmmo.text = gun.currentAmmoInMag.ToString();
        ammoHeld.text = gun.ammoBeingHeld.ToString();
        roundNumber.text = (roundSpawner.currentWaveNumber + 1).ToString();
    }
}
