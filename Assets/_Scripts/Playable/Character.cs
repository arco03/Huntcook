using System;
using Interactable;
using UnityEngine;

namespace Playable
{
    [Serializable]
    [RequireComponent((typeof(Rigidbody)))]
    public class Character : MonoBehaviour
    {
        //Dependencies
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float radius;
        [SerializeField] private Vector3 offsetUpper;
        [SerializeField] private Vector3 offsetLower;
        [SerializeField] private LayerMask mask;
        
        private Rigidbody _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        public void Move(float x, float z)
        { 
            Vector3 forwardMovement = transform.forward * (z * speed);
            
            _rb.velocity = new Vector3(forwardMovement.x, _rb.velocity.y, forwardMovement.z);
            
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * (x * rotationSpeed * Time.fixedDeltaTime));
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }

        public void Use()
        {
            // Physics.OverlapSphere(transform.position, _radius,_mask);
            Vector3 rotatedOffsetUpper = transform.rotation * offsetUpper;
            Vector3 rotatedOffsetLower = transform.rotation * offsetLower;

            Collider [] colliders = Physics.OverlapCapsule(
                transform.position + rotatedOffsetUpper,
                transform.position + rotatedOffsetLower,
                radius,
                mask);
           
            foreach (Collider colliderDetected in colliders)
            { 
                if(!colliderDetected) continue;
           
                colliderDetected.gameObject.TryGetComponent<IDetector>(out IDetector component);
                component?.Interaction(this);
                Debug.Log("Entra aca");
                break;
            }
        }
        
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
    
            // Rotamos los offsets junto con el personaje
            Vector3 rotatedOffsetUpper = transform.rotation * offsetUpper;
            Vector3 rotatedOffsetLower = transform.rotation * offsetLower;

            // Dibujamos la cápsula con los offsets rotados
            Gizmos.DrawWireSphere(rotatedOffsetUpper + transform.position, radius);
            Gizmos.DrawWireSphere(rotatedOffsetLower + transform.position, radius);
            Gizmos.DrawLine(rotatedOffsetUpper + radius * transform.right + transform.position, rotatedOffsetLower + radius * transform.right + transform.position);
            Gizmos.DrawLine(rotatedOffsetUpper - radius * transform.right + transform.position, rotatedOffsetLower - radius * transform.right + transform.position);
        }


    }
}

