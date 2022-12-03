using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30;
    [SerializeField] ParticleSystem muzzleVFX;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] bool isRifle;

    bool canShoot = true;

    void OnEnable()
    {
        canShoot = true;
    }
    
    void Update()
    {
        if(isRifle)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                InvokeRepeating("ShootRifle", .001f, fireRate);
            }
            else if (Input.GetMouseButtonUp(0)) 
            {
                CancelInvoke("ShootRifle");
            }
        }
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
           
            StartCoroutine(Shoot());
            
        }   
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    void ShootRifle()
    {
        if(ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleVFX.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
