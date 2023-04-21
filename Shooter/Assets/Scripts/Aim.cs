using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField] private float hp = 10;
    [SerializeField] private Slider healthBar;

    public GameObject deadEffect;

    private void Awake()
    {
        
        healthBar.maxValue = hp;
        healthBar.value = hp;
    }

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
        healthBar.value = hp;
    }

}
