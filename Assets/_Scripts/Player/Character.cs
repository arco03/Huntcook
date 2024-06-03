using System;
using System.Collections;
using _Scripts.Ghost;
using _Scripts.Installer;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    [Serializable]
    [RequireComponent((typeof(Rigidbody)))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float radius;
        [SerializeField] private Vector3 offsetUpper;
        [SerializeField] private Vector3 offsetLower;
        [SerializeField] private LayerMask ingredientMask;
        [SerializeField] private LayerMask ghostMask;
        [SerializeField] private float attackRadius;
        [SerializeField] private Transform collectPoint;
        [SerializeField] private Animator animator;
        
        private int _attackDamage = 1;
        public bool isAttacking;
        private Rigidbody _rb;
        public bool capture = true;
        
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
                ingredientMask);
           
            foreach (Collider colliderDetected in colliders)
            { 
                if(!colliderDetected) continue;
           
                colliderDetected.gameObject.TryGetComponent<IDetector>(out IDetector component);
                component?.Interaction(collectPoint,capture=false);
                Debug.Log("Entra aca");
                break;
            }
        }

        public void Animator()
        {
            animator.SetTrigger("Hand");
        }
        
        public void Attack()
        {
            Vector3 rotatedOffsetUpperAttack = transform.rotation * offsetUpper;
            Vector3 rotatedOffsetLowerAttack = transform.rotation * offsetLower;

            Collider [] colliders = Physics.OverlapCapsule(
                transform.position + rotatedOffsetUpperAttack,
                transform.position + rotatedOffsetLowerAttack,
                attackRadius,
                ghostMask);

            foreach (Collider ghost in colliders)
            {
                ghost.gameObject.TryGetComponent<Ghost.Ghost>(out Ghost.Ghost phantom);
                phantom?.TakeDamage(_attackDamage);
            }

            isAttacking = false;
        }

        void OnDrawGizmos()
        {
            //Ingredient Gizmos
            Gizmos.color = Color.red;
    
            // Rotamos los offsets junto con el personaje
            Vector3 rotatedOffsetUpper = transform.rotation * offsetUpper;
            Vector3 rotatedOffsetLower = transform.rotation * offsetLower;

            // Dibujamos la cápsula con los offsets rotados
            Gizmos.DrawWireSphere(rotatedOffsetUpper + transform.position, radius);
            Gizmos.DrawWireSphere(rotatedOffsetLower + transform.position, radius);
            Gizmos.DrawLine(rotatedOffsetUpper + radius * transform.right + transform.position, rotatedOffsetLower + radius * transform.right + transform.position);
            Gizmos.DrawLine(rotatedOffsetUpper - radius * transform.right + transform.position, rotatedOffsetLower - radius * transform.right + transform.position);
            
            //Ghost Gizmos
            Gizmos.color = Color.green;
    
            // Rotamos los offsets junto con el personaje
            Vector3 rotatedOffsetUpperAttack = transform.rotation * offsetUpper;
            Vector3 rotatedOffsetLowerAttack = transform.rotation * offsetLower;

            // Dibujamos la cápsula con los offsets rotados
            Gizmos.DrawWireSphere(rotatedOffsetUpperAttack + transform.position, attackRadius);
            Gizmos.DrawWireSphere(rotatedOffsetLowerAttack + transform.position, attackRadius);
            Gizmos.DrawLine(rotatedOffsetUpperAttack + attackRadius * transform.right + transform.position, rotatedOffsetLowerAttack + attackRadius * transform.right + transform.position);
            Gizmos.DrawLine(rotatedOffsetUpperAttack - attackRadius * transform.right + transform.position, rotatedOffsetLowerAttack - attackRadius * transform.right + transform.position);
        }


    }
}

