using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Ghost
{
    public class IA : MonoBehaviour
    {
        public NavMeshAgent _agent;

        public void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Update()
        {
            _agent.SetDestination(new Vector3(0f,0f,0f));
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation

            // _agent.SetDestination(ghost.enemy.transform.position);
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