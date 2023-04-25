using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Material newMatereal;
    [SerializeField] private Renderer flagRenderer;
    private bool isReached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isReached)
        {
            isReached = true;
            FlagCounter.Instance.MarkFlag();
            flagRenderer.material = newMatereal;
        }
    }
}
