using Interactable;
using Playable;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(menuName = "Create Ingredients", fileName = "Ingredients")]
    public class IngredientsData : ScriptableObject
    {
        [HideInInspector] public int id;
        // public string ingredientName;
        // public Sprite sprite;
        // public Ingredient ingredientPrefab; //Aun no estoy segura del tipo de dato 

        public List<Ingredient> prefabs;
        public Ingredient GetPrefab(int id)
        {
            this.id = id;
            return prefabs.Find(food => food.id == id);

        }
    }
}
