using System;
using System.Collections.Generic;
using System.Drawing;
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
       
        Search,
        Taken,
    }
    public class IA : MonoBehaviour
    {
        public StateIa _point;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private String name;
        private readonly Dictionary<StateIa, Vector3> _positions = new Dictionary<StateIa, Vector3>();
        [SerializeField] private Vector3 offsetUpper;
        [SerializeField] private Vector3 offsetLower;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask ingredientMask;
        private List<IngredientPoint> pointIngredient;
        private Ingredient.Ingredient _ingredient;
        private Ghost _ghost;
        private IngredientData _ingredientData;
        private bool _ghostDetection = false;
        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _ghost = FindObjectOfType<Ghost>();
             pointIngredient = GameInstaller.Instance.ingredientPoints;
             _ingredient = FindObjectOfType<Ingredient.Ingredient>();
            
        }
        public void Update()
        {
           Location();
           Detection();
           Move(_point);

        }

         private void Move(StateIa state)
         {
             Vector3 destine = _positions[state];
             agent.SetDestination(destine);
        
         }

         private void Location()
         {
            
             foreach (var points in pointIngredient)
             {
                  if (points.state == PointState.Taken && points.ingredientData.ingredientName == name)
                 {
                     _positions[StateIa.Search] = points.transform.position;
                     _point = StateIa.Search;
                     break; 
                 }
                  
             }

     
             
         }



         // ReSharper disable Unity.PerformanceAnalysis
         private void Detection()
         {
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
                     component?.Interaction(this.transform);
                     
                     
                     var transformPosition = GameInstaller.Instance._ghostSpawner.Enemypositions;
                      _point = StateIa.Taken;
                     _positions[StateIa.Taken] = transformPosition;
                     // _ghostDetection = true;
                     break;
             }
         }

         // private void OnTriggerEnter(Collider other)
         // {
         //     if (other.gameObject.CompareTag("Door") && _ghostDetection)
         //     {
         //         Destroy(this._ingredient.gameObject);
         //         _point = StateIa.Search;
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