using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class meat : MonoBehaviour
{
    private Rigidbody _rb;
    void Awake()
    {
        _rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
