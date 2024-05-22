using System.Collections.Generic;
using Installer;
using Interactable;
using UnityEngine;

namespace Spawner
{
    public class IngredientSpawner
    {
        private readonly List<Ingredient> _ingredientsSpawned = new List<Ingredient>();
        private readonly Dictionary<int, Transform> _ingredientsPoints = new Dictionary<int, Transform>();
        private readonly List<Transform> _ingredientsSpawnPoints;
        private readonly FactoryFood _factory;
        private readonly List<Ingredient> _recipeIngredients;
        
        public IngredientSpawner(List<Transform> ingredientsSpawnPoints, FactoryFood factory, List<Ingredient> recipeIngredients)
        {
            _ingredientsSpawnPoints = ingredientsSpawnPoints;
            _factory = factory;
            _recipeIngredients = recipeIngredients;
        }

        public void Initialize()
        {
            foreach (Ingredient ingredient in _recipeIngredients)
            {
                int randomIndex = Random.Range(0, _ingredientsSpawnPoints.Count);

                Transform randomSpawnPoint = _ingredientsSpawnPoints[randomIndex];
                Ingredient food = _factory.Create(ingredient.id);
                
                _ingredientsSpawned.Add(food);
                _ingredientsPoints.Add(ingredient.id, randomSpawnPoint);
                food.transform.position = new Vector3(randomSpawnPoint.position.x,randomSpawnPoint.position.y,randomSpawnPoint.position.z);
            }

        }

        public void Spawn()
        {
            
        }

    }
}