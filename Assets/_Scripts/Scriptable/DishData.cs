using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(menuName = "DishData", fileName = "DishData")]
    public class DishData : ScriptableObject
    {
        public string recipeName;
        public Sprite sprite;
        public List <IngredientData> ingredientsList;
    }
}