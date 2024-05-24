using System.Collections.Generic;
using Interactable;
using UnityEngine;

namespace Scriptable
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