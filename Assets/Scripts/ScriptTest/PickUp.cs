using System;
using Interactable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
[RequireComponent(typeof(Rigidbody))]
public class PickUp : MonoBehaviour
{ 
    
    [SerializeField] private GameObject _player; 
    public float radius;
    public LayerMask mask;
    private Rigidbody _rb;
    public bool inspeccion = true;
    
   private void Usar()
   {

       Collider [] colliders = Physics.OverlapSphere(transform.position, radius,mask);
       foreach (Collider colliderDetected in colliders)
        { 
           if(!colliderDetected) continue;
           //
           
           colliderDetected.gameObject.TryGetComponent<IDetector>(out IDetector component);
           component?.Interaction();

        }
            
    }

   private void Start()
   {
       _rb = GetComponent<Rigidbody>();
   }

   void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            Usar();
        }

    }

}
