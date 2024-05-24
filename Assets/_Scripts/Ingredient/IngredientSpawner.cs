using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Ingredient
{
    public class IngredientSpawner
    {
        private readonly List<IngredientData> _dishIngredients;
        private readonly List<IngredientPoint> _ingredientsPoints;
        private readonly IngredientFactory _factory;
        
        public IngredientSpawner(List<IngredientData> dishIngredients, List<IngredientPoint> ingredientsSpawnPoints, IngredientFactory factory)
        {
            _dishIngredients = dishIngredients;
            _ingredientsPoints = ingredientsSpawnPoints;
            _factory = factory;
        }

        public void Initialize()
        {
            if (_dishIngredients.Count >= _ingredientsPoints.Count)
                throw new Exception("The amount of ingredients is greater than the ingredients points");
            
            foreach (IngredientData ingredientData in _dishIngredients)
            {
                int randomIndex;
                while (true)
                {
                    randomIndex = Random.Range(0, _ingredientsPoints.Count);
                    if (!_ingredientsPoints[randomIndex].ingredientData) break;
                }
                
                IngredientPoint ingredientPoint = _ingredientsPoints[randomIndex];
                Ingredient food = _factory.Create(ingredientData);
                ingredientPoint.ingredientData = ingredientData;

                Vector3 ingredientPointTransform = ingredientPoint.transform.position;
                food.transform.position = new Vector3(ingredientPointTransform.x, ingredientPointTransform.y, ingredientPointTransform.z);
                
            }
        }

        public void Spawn()
        {
            foreach (IngredientPoint ingredientPoint in _ingredientsPoints)
            {
                if (!ingredientPoint.ingredientData) continue;
                
                if (ingredientPoint.state == PointState.Free)
                {
                    Ingredient food = _factory.Create(ingredientPoint.ingredientData);
                    Vector3 ingredientPointTransform = ingredientPoint.transform.position;
                    food.transform.position = new Vector3(ingredientPointTransform.x, ingredientPointTransform.y, ingredientPointTransform.z);
                }
            }
        }

    }
}