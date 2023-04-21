using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 5f;
    public float range = 100f;

    public Camera cam;

    public AudioSource shootSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        shootSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            var aim = hit.transform.GetComponent<Aim>();
            if (aim != null)
            {
                hit.transform.GetComponent<Aim>().TakeDamage(damage);
            }
        }
    }
}
