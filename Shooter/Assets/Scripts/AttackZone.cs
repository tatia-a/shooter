using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private bool playerInZone;

    public bool PlayerInZone { get { return playerInZone; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInZone = false;
        }
    }
}
