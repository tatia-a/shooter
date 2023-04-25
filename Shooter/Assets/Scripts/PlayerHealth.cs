using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 30;

    public float Health { get => health; }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
