using System.Collections.Generic;
using _Scripts.Ingredient;
using _Scripts.Installer;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Ghost
{
    public enum StateIa
    {
        Search,
        Idle,
    }
    
    [RequireComponent(typeof(NavMeshAgent))]
    public class Ghost : MonoBehaviour
    {
        public StateIa currentState;
        public GhostData ghostData;
        
        [SerializeField] private IngredientData data;
        [SerializeField] private Vector3 offsetUpper;
        [SerializeField] private Vector3 offsetLower;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask ingredientMask;
        [SerializeField] private Transform collectPoint;
        
        private readonly Dictionary<StateIa, Vector3> _positions = new Dictionary<StateIa, Vector3>();
        
        private NavMeshAgent _agent;
        private IngredientData _ingredientData;
        public bool hasIngredient;

        private IngredientPoint _assignPoint;
        private Ingredient.Ingredient _currentIngredient;
        
        private int _maxHealth;
        private int _currentHealth;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Start()
        {
            _maxHealth = 3;
            _currentHealth = _maxHealth;
            
            _agent = GetComponent<NavMeshAgent>();
            StoreInitialPosition();
            StoreIngredient();
        }

        private void StoreInitialPosition()
        {
            _positions[StateIa.Idle] = transform.position;
        }

        private void StoreIngredient()
        {
            List<IngredientPoint> pointIngredient= GameInstaller.Instance.ingredientPoints;
             
            foreach (IngredientPoint currentPoint in pointIngredient)
            {
                if (currentPoint.ingredientData == data)
                {
                    _assignPoint = currentPoint;
                    _positions[StateIa.Search] = currentPoint.transform.position;
                    break; 
                }
            }
        }
        
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _currentIngredient.Interaction(transform);
                Destroy(gameObject);
            }
            
        }

        public void Update()
        {
            UpdateStates();
        }

        private void Move(StateIa state)
        {
            Vector3 destine = _positions[state];
            _agent.SetDestination(destine);
        }

        private void UpdateStates()
        {

            if (_assignPoint.state == PointState.Taken && !hasIngredient)
            {
                currentState = StateIa.Search;
                if (Vector3.Distance(transform.position, _assignPoint.transform.position) <= 1f)
                {
                    Detection();
                }
            }
            else
            {
                currentState = StateIa.Idle;
                Vector3 point = _positions[currentState];
                if (Vector3.Distance(transform.position, point) <= 1f)
                {
                    if (_currentIngredient)
                    {
                        _currentIngredient.Destroy();
                        hasIngredient = false;
                    }
                }
            }
            
            Move(currentState);

        }

        private void Detection()
        {
            if (hasIngredient) return;
             
            Vector3 rotatedOffsetUpper = transform.rotation * offsetUpper;
            Vector3 rotatedOffsetLower = transform.rotation * offsetLower;

            Collider[] results = new Collider[4];
            Physics.OverlapCapsuleNonAlloc(transform.position + rotatedOffsetUpper, transform.position + rotatedOffsetLower, radius, results, ingredientMask);
           
            foreach (Collider colliderDetected in results)
            { 
                if(!colliderDetected) continue;
                
                colliderDetected.gameObject.TryGetComponent(out Ingredient.Ingredient ingredient);
                if (ingredient.ingredientData != data) continue;

                ingredient.Interaction(collectPoint);
                _currentIngredient = ingredient;
                hasIngredient = true;
                currentState = StateIa.Idle;
                break;
            }
        }

        void OnDrawGizmos()
        {
            // Ingredient Gizmos
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