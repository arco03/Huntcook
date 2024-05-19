using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class meat : MonoBehaviour
{
    private Rigidbody _rb;
    void Awake()
    {
        _rb.useGravity = false;
    }
    
}
