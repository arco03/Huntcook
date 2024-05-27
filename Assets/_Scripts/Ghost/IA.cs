using System;
using System.Collections.Generic;
using System.Drawing;
using _Scripts.Ingredient;
using _Scripts.Installer;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Color = UnityEngine.Color;

namespace _Scripts.Ghost
{
    public enum StateIa
    {
        Search,
        Taken,
    }
    public class IA : MonoBehaviour
    {
        private StateIa _point;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private String name;
        private readonly Dictionary<StateIa, Vector3> _positions = new Dictionary<StateIa, Vector3>();
        [SerializeField] private Vector3 offsetUpper;
        [SerializeField] private Vector3 offsetLower;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask ingredientMask;
        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
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
             var pointIngredient = GameInstaller.Instance.ingredientPoints;
             foreach (var points in pointIngredient)
             {
                 if (points.state == PointState.Taken && points.ingredientData.ingredientName == name)
                 {
                     _positions[StateIa.Search] = points.transform.position;
                     _point = StateIa.Search;
                     return; 
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
                 
                 _positions[StateIa.Taken] = new Vector3(0f, 0f, 0f);
                 _point = StateIa.Taken;
                 // if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                 // {
                 //     Ingredient.Ingredient ingredient = colliderDetected.GetComponent<Ingredient.Ingredient>();
                 //     Destroy(ingredient.gameObject);
                 // }

                 break;
             }
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
            
         }
         

    

     

        // public GameObject prefabDelObjeto; // Asigna el prefab desde el editor de Unity
        //
        // void Start()
        // {
        //     GhostSpawner ghost = GetComponent<GhostSpawner>();
        //     GameObject objetoInstanciado = ghost.Spawn();
        //     Vector3 posicionObjetoInstanciado = objetoInstanciado.transform.position;
        //
        //     // Asigna la posición del objeto instanciado a otro objeto
        //     otroObjeto.transform.position = posicionObjetoInstanciado;
        // }
        // public GameObject prefabAgente; // Asigna el prefab del agente desde el editor de Unity
        // private GameObject agenteInstanciado;
        // private NavMeshAgent navMeshAgent;
        // private GhostSpawner _ghostSpawner;
        // void Start()
        // {
        //    
        //     // Instancia el agente
        //     // agenteInstanciado = Instantiate(prefabAgente, transform.position, transform.rotation);
        //
        //     // Asegúrate de que el agente instanciado tenga un componente NavMeshAgent
        //     navMeshAgent = agenteInstanciado.GetComponent<NavMeshAgent>();
        //     if (navMeshAgent == null)
        //     {
        //         // Si no tiene un componente NavMeshAgent, agrégalo
        //         navMeshAgent = agenteInstanciado.AddComponent<NavMeshAgent>();
        //     }
        //
        //     // Configura el NavMeshAgent según sea necesario
        //     // Por ejemplo:
        //     navMeshAgent.speed = 3f; // Velocidad del agente
        //     navMeshAgent.angularSpeed = 120f; // Velocidad de rotación del agente
        //     navMeshAgent.acceleration = 8f; // Aceleración del agente
        //
        //     // Establece el destino del NavMeshAgent
        //     navMeshAgent.SetDestination(new Vector3(10f, 0f, 10f)); // Cambia esto según tu lógica de juego
        // }
        

        
    }
}