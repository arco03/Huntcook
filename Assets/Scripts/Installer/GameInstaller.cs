using System;
using System.Collections;
using System.Collections.Generic;
using Interactable;
using Playable;
using Scriptable;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Installer
{
    [RequireComponent(typeof(Transform))]
    public class GameInstaller : MonoBehaviour
    {
        [Header("Spawner configurations")]
        [SerializeField] private ListGhost config;
        [SerializeField] private IngredientsData configFood;
        
        [Header("Spawner Positions")]
        [SerializeField] private Transform ghostVector1;
        [SerializeField] private Transform ghostVector2;
        [SerializeField] private List<Transform> ingredientsSpawnPoints;
        
        private ConfigureFactory _enemy;
        private FactoryFood _food;

        public int id;

        public void Awake()
        {
            _enemy = new ConfigureFactory(config);
            _food = new FactoryFood(configFood);

        }

        private void Start()
        {
            StartCoroutine(Timer());

        }
        

        public void Spawners()
        {
            for (int i = 0; i < 3; i++)
            {
                float posEnemyX = Random.Range(Mathf.Max(ghostVector1.position.x, ghostVector2.position.x),Mathf.Min(ghostVector1.position.x, ghostVector2.position.x));
                float posEnemyZ = Random.Range(Mathf.Max(ghostVector1.position.z, ghostVector2.position.z), Mathf.Min(ghostVector1.position.z, ghostVector2.position.z));
                
                int randomIndex = Random.Range(0, ingredientsSpawnPoints.Count);
                
                Transform randomSpawnPoint = ingredientsSpawnPoints[randomIndex];
                
                GhostGame enemy = _enemy.Create(0);
                Ingredient food = _food.Create(i);

                food.transform.position = new Vector3(randomSpawnPoint.position.x,randomSpawnPoint.position.y,randomSpawnPoint.position.z);
                enemy.transform.position = new Vector3(posEnemyX, 1f, posEnemyZ);
                
                
                
                //float posFoodX = Random.Range(Mathf.Max(ingredientsVector1.position.x,ingredientsVector2.position.x),Mathf.Min(ingredientsVector1.position.x,ingredientsVector2.position.x));
               //float posFoodZ = Random.Range(Mathf.Max(ingredientsVector1.position.z,ingredientsVector2.position.z),Mathf.Min(ingredientsVector1.position.z,ingredientsVector2.position.z));
                // enemy.AddIngredient(food);
            }
        }
        IEnumerator Timer()
        {
            
            yield return new WaitForSeconds(5f);
            Spawners();
            
        }
    }
}


