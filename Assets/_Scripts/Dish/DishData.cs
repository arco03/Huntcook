using System.Collections.Generic;
using _Scripts.Ingredient;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Dish
{
    [CreateAssetMenu(menuName = "DishData", fileName = "DishData")]
    public class DishData : ScriptableObject
    {
        public string recipeName;
        public Sprite image;
        public int amount;
        public List <IngredientData> ingredientsList;
        public int n1, n2;

        private void OnEnable()
        {
            amount = Random.Range(n1, n2);
        }
    }
}