using System;
using UnityEngine;

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
        [SerializeField] private Transform collectPoint;
        [SerializeField] private Animator animator;
        
        [Header("Attack Config")]
        [SerializeField] private float attackRadius;
        [SerializeField] private int attackDamage = 1;
        public bool isAttacking;
        public bool detection = false;
        private Rigidbody _rb;
        private Ingredient.Ingredient _currentIngredient;
        
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
            if (_currentIngredient)
            {
                _currentIngredient.Interaction(collectPoint);
                _currentIngredient = null;
                return;
            }
            
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
                colliderDetected.gameObject.TryGetComponent<Ingredient.Ingredient>(out Ingredient.Ingredient component);
                detection = true;
                if (!component.isPicked)
                {
                    component.Interaction(collectPoint);
                    _currentIngredient = component;
                    return;
                }
            }
        }

        public void Animator(String typeAnim)
        {
            animator.SetTrigger(typeAnim);
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
                phantom?.TakeDamage(attackDamage);
            }

            isAttacking = false;
        }

        // void OnDrawGizmos()
        // {
        //     //Ingredient Gizmos
        //     Gizmos.color = Color.red;
        //
        //     // Rotamos los offsets junto con el personaje
        //     Vector3 rotatedOffsetUpper = transform.rotation * offsetUpper;
        //     Vector3 rotatedOffsetLower = transform.rotation * offsetLower;
        //
        //     // Dibujamos la cápsula con los offsets rotados
        //     Gizmos.DrawWireSphere(rotatedOffsetUpper + transform.position, radius);
        //     Gizmos.DrawWireSphere(rotatedOffsetLower + transform.position, radius);
        //     Gizmos.DrawLine(rotatedOffsetUpper + radius * transform.right + transform.position, rotatedOffsetLower + radius * transform.right + transform.position);
        //     Gizmos.DrawLine(rotatedOffsetUpper - radius * transform.right + transform.position, rotatedOffsetLower - radius * transform.right + transform.position);
        //     
        //     //Ghost Gizmos
        //     Gizmos.color = Color.green;
        //
        //     // Rotamos los offsets junto con el personaje
        //     Vector3 rotatedOffsetUpperAttack = transform.rotation * offsetUpper;
        //     Vector3 rotatedOffsetLowerAttack = transform.rotation * offsetLower;
        //
        //     // Dibujamos la cápsula con los offsets rotados
        //     Gizmos.DrawWireSphere(rotatedOffsetUpperAttack + transform.position, attackRadius);
        //     Gizmos.DrawWireSphere(rotatedOffsetLowerAttack + transform.position, attackRadius);
        //     Gizmos.DrawLine(rotatedOffsetUpperAttack + attackRadius * transform.right + transform.position, rotatedOffsetLowerAttack + attackRadius * transform.right + transform.position);
        //     Gizmos.DrawLine(rotatedOffsetUpperAttack - attackRadius * transform.right + transform.position, rotatedOffsetLowerAttack - attackRadius * transform.right + transform.position);
        // }


    }
}

