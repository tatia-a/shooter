using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform cam;

    private void Awake()
    {
        cam = Camera.main.GetComponent<Transform>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
}
