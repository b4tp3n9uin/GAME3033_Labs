using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{ 
    None, Pistol, MachineGun
}

public enum WeaponFiringPattern
{ 
    SemiAuto, FullAuto, ThreeShotBurst, FiveShotBurst, PumpAction
}

[System.Serializable]
public struct WeaponStats {
    public WeaponType weaponType;
    public WeaponFiringPattern firingPattern;
    public string weaponName;
    public float damage;
    public int bulletsInClip;
    public int clipSize;
    public float fireStartDelay;
    public float fireRate;
    public float fireDistance;
    public bool repeating;
    public LayerMask weaponHitLayers;
    public int totalBullets;
}

public class WeaponComponent : MonoBehaviour
{
    public Transform gripLocation;
    public WeaponStats weaponStats;
    protected WeaponHolder weaponHolder;
    [SerializeField]
    protected ParticleSystem gunFiring;

    public bool isFiring;
    public bool isReloading;
    


    protected Camera mainCamera;
   
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(WeaponHolder _weaponHolder)
    {
        weaponHolder = _weaponHolder;
    }

    public virtual void StartFiringWeapon()
    {
        isFiring = true;
        if (weaponStats.repeating)
        {
            //fire weapon
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireRate);
        }
        else
        {
            FireWeapon();
        }
    }

    public virtual void StopFiringWeapon()
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));
        if (gunFiring && gunFiring.isPlaying)
        {
            gunFiring.Stop();
        }
    }

    protected virtual void FireWeapon()
    {
        //print("Firing weapon!");
        weaponStats.bulletsInClip--;
        print(weaponStats.bulletsInClip);
    }

    public virtual void StartReloading()
    {
        isReloading = true;
        ReloadWeapon();
    }

    public virtual void FinishReloading()
    {
        isReloading = false;
    }

    //Set ammo count
    protected virtual void ReloadWeapon()
    {
        //Check for firing effect and stop.
        if (gunFiring && gunFiring.isPlaying)
        {
            gunFiring.Stop();
        }

        int bulletsToReload = weaponStats.clipSize - weaponStats.totalBullets;
        if (bulletsToReload < 0)
        {
            // Make sure when you reload it keeps the remaining bullets on count.
            int remainingBulletsInClip;
            remainingBulletsInClip = weaponStats.clipSize - weaponStats.bulletsInClip;

            weaponStats.bulletsInClip = weaponStats.clipSize;
            weaponStats.totalBullets -= remainingBulletsInClip;
        }
        else
        {
            weaponStats.bulletsInClip = weaponStats.totalBullets;
            weaponStats.totalBullets = 0;
        }
    }
}
