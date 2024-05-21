using System;
using Interactable;
using UnityEditor;
using UnityEngine;

namespace Playable
{
    [Serializable]
    [RequireComponent((typeof(Rigidbody)))]
    public class Character : MonoBehaviour
    {
        //Dependencies
        private float _speed;
        private float _rotationSpeed;
        private float _radius;
        private LayerMask _mask;
        //[SerializeField] Transform _transform;
        
        
        private Rigidbody _rb;

        public void CharacterSetUp(float speed,float rotationSpeed, float radius, LayerMask mask)
        {
           
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _radius = radius;
            _mask = mask;
            
        }


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Move(float x, float z)
        { 
            Vector3 forwardMovement = transform.forward * (z * _speed);
            
            _rb.velocity = new Vector3(forwardMovement.x, _rb.velocity.y, forwardMovement.z);
            
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * (x * _rotationSpeed * Time.fixedDeltaTime));
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }

        public void Use()
        {
            // Physics.OverlapSphere(transform.position, _radius,_mask);
            Collider [] colliders = Physics.OverlapCapsule(transform.position,transform.position, _radius, _mask);
            foreach (Collider colliderDetected in colliders)
            { 
                if(!colliderDetected) continue;
           
                colliderDetected.gameObject.TryGetComponent<IDetector>(out IDetector component);
                component?.Interaction();
            }
        }
    }
}

