using Interactable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject meat; 
    public float radius;
    public LayerMask mask;
   private void Collision()
   {

       Collider [] colliders = Physics.OverlapSphere(transform.position, radius,mask);
       foreach (Collider colliderDetected in colliders)
        { 
           if(!colliderDetected) continue;

           colliderDetected.gameObject.TryGetComponent<IDetector>(out IDetector component);
           component?.Interaction();
            meat.transform.SetParent(this.transform);
            meat.transform.localPosition = new Vector3(0f, 0f, -0.930999994f);
        }
            
    }


    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {

            Collision();
        }
    }

}
