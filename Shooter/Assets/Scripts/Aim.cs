using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private float hp = 10;

    public GameObject deadEffect;

    private void Update()
    {
        CheckHP();
    }

    private void CheckHP()
    {
        if (hp <= 0)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }
    
    public void TakeDamage(float damage)
    {
        if(hp > 0) hp -= damage;
    }

}
