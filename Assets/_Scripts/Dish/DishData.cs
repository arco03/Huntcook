using System;
using System.Collections.Generic;
using _Scripts.Ingredient;
using UnityEngine;

namespace _Scripts.Dish
{
    [CreateAssetMenu(menuName = "DishData", fileName = "DishData")]
    public class DishData : ScriptableObject
    {
        public string recipeName;
        public Sprite image;
        public int amount;
        public List <IngredientData> ingredientsList;

    }
}