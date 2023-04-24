using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private WeaponSwitcher weaponSwitcher;

    [SerializeField] private AudioSource shootSound;
    [SerializeField] private GameObject impactEffect;

    private float timer = 0;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if(Input.GetButtonDown("Fire1") && !PauseManager.instance.GetPauseState())
            {
                Shoot();
                timer = weaponSwitcher.SelectedWeapon.Cooldown;
            }
        }
        
        
    }

    private void Shoot()
    {
        Weapon selectedWeapon = weaponSwitcher.SelectedWeapon;
        shootSound.Play();
        selectedWeapon.MakeShootEffect();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            var aim = hit.transform.GetComponent<Aim>();
            if (aim != null)
            {
                print(selectedWeapon.Damage);
                hit.transform.GetComponent<Aim>().TakeDamage(selectedWeapon.Damage);
            }

            var impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
