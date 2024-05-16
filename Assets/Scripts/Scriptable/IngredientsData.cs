using Interactable;
using Playable;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(menuName = "Create Ingredients", fileName = "Ingredients")]
    public class IngredientsData : ScriptableObject
    {
        public int id;
        public string ingredientName;
        public Sprite sprite;
        public Ingredient ingredientPrefab; //Aun no estoy segura del tipo de dato 
    }
}
