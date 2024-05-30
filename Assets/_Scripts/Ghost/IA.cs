using System;
using System.Collections.Generic;
using _Scripts.Ingredient;
using _Scripts.Installer;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Color = UnityEngine.Color;
using State = _Scripts.Ingredient.State;

namespace _Scripts.Ghost
{
    public enum StateIa
    {
        Stop,
        Search,
        Mine,
    }
    public class IA : MonoBehaviour
    {
        public StateIa point;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private IngredientData data;
        private readonly Dictionary<StateIa, Vector3> _positions = new Dictionary<StateIa, Vector3>();
        [SerializeField] private Vector3 offsetUpper;
        [SerializeField] private Vector3 offsetLower;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask ingredientMask;
        [SerializeField] private Transform collectPoint;
        private Vector3 transformPosition;
        private Ingredient.Ingredient _ingredient;
        private IngredientData _ingredientData;
        public bool _ghostDetection = false;
     
        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _ingredient = FindObjectOfType<Ingredient.Ingredient>();
            transformPosition = GameInstaller.Instance._ghostSpawner.Enemypositions;
            
          
        }
        public void Update()
        {
           
            SetUpLocation();
            Move(point);
        }

        private void FixedUpdate()
        {
            Detection(); 
        }

        private void Move(StateIa state)
         {
             Vector3 destine = _positions[state];
             agent.SetDestination(destine);
         }

        // ReSharper disable Unity.PerformanceAnalysis
        private void SetUpLocation()
         {
             List<IngredientPoint> pointIngredient= GameInstaller.Instance.ingredientPoints;
             
             foreach (IngredientPoint points in pointIngredient)
             {
                  if (points.state == PointState.Taken && points.ingredientData == data)
                 {
                     _positions[StateIa.Search] = points.transform.position;
                     point = StateIa.Search;
                     break; 
                 }

                 // if (points.ingredientData == data && points.state == PointState.Free)
                 // {
                 //     // _positions[StateIa.Stop] = new Vector3(0f, 0f, 0f);
                 //     
                 //     _positions[StateIa.Stop] = transform.position;
                 //     point = StateIa.Stop;
                 //     break;
                 // }
                 
             }

             if (_ghostDetection)
             {
                 _positions[StateIa.Mine] = transformPosition;
                 point = StateIa.Mine;
                 if (agent.remainingDistance <= agent.stoppingDistance)
                 {
                     _positions[StateIa.Stop] = new Vector3(0f, 0f, 0f);
                     
                     _positions[StateIa.Stop] = transform.position;
                     if (_ingredient != null)
                     {
                         _ingredient.Destroy();
                         point = StateIa.Search;
                     }

                 }
                 
             }



         }
         

         private void Detection()
         {
             if (_ghostDetection) return;
             
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
                
                colliderDetected.gameObject.TryGetComponent(out Ingredient.Ingredient ingredient);
                if (ingredient.ingredientData != data) continue;

                ingredient.Interaction(collectPoint);
               _ghostDetection = true;
                break;
             }
         }

         // private void OnTriggerEnter(Collider other)
         // {
         //     if (other.gameObject.CompareTag("Door") && _ingredient.currentState == State.Captured)
         //     {
         //         Debug.Log("LLego");
         //         // _positions[StateIa.Stop] = transform.position;
         //         // point = StateIa.Stop;
         //
         //     }
         // }


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
            
         }
  
        

        
    }
}