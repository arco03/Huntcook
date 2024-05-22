using System;
using System.Collections;
using System.Collections.Generic;
using Interactable;
using Playable;
using Scriptable;
using Spawner;
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
        [SerializeField] private RecipeData _recipeData;

        // MonoState
        public static List<Ingredient> Ingredients = new List<Ingredient>();
        public static List<GhostGame> Ghosts = new List<GhostGame>();

        private ConfigureFactory _enemy;
        private IngredientSpawner _ingredientSpawner;

        public int id;

        public void Awake()
        {
            _enemy = new ConfigureFactory(config);
            FactoryFood factoryFood = new FactoryFood(configFood);
            _ingredientSpawner = new IngredientSpawner(ingredientsSpawnPoints, factoryFood, _recipeData.recipeList);
        }

        private void Start()
        {
            _ingredientSpawner.Initialize();
        }
        
        private void SpawnGhosts()
        {
            for (int i = 0; i < 3; i++)
            {
                float posEnemyX = Random.Range(Mathf.Max(ghostVector1.position.x, ghostVector2.position.x),Mathf.Min(ghostVector1.position.x, ghostVector2.position.x));
                float posEnemyZ = Random.Range(Mathf.Max(ghostVector1.position.z, ghostVector2.position.z), Mathf.Min(ghostVector1.position.z, ghostVector2.position.z));
                GhostGame enemy = _enemy.Create(0);
                
                Ghosts.Add(enemy);
                
                enemy.transform.position = new Vector3(posEnemyX, 1f, posEnemyZ);
            }
        }


    }
}


