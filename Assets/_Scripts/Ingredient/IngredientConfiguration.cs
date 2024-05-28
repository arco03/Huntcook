using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Ingredient
{
    [CreateAssetMenu(menuName = "IngredientConfiguration", fileName = "IngredientConfiguration")]
    public class IngredientConfiguration : ScriptableObject
    {
        public List<Ingredient> ingredients;
        
        public Ingredient GetPrefab(IngredientData data)
        {
            return ingredients.Find(ingredient => ingredient.ingredientData == data);
        }
    }
}