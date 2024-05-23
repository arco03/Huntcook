using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(menuName = "IngredientData", fileName = "IngredientData")]
    public class IngredientData : ScriptableObject
    {
        public string ingredientName;
        public Sprite sprite;
    }
}
