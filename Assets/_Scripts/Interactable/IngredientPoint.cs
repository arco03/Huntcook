using System;
using Scriptable;
using UnityEngine;

namespace Interactable
{
    [Serializable]
    public enum PointState
    {
        Free,
        Taken,
    }
    
    public class IngredientPoint : MonoBehaviour
    {
        public PointState state;
        public IngredientData ingredientData;
        
        private void Start() => GetComponent<MeshRenderer>().enabled = false;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Ingredient>(out Ingredient ingredient))
            {
                if (ingredient.ingredientData == ingredientData)
                {
                    state = PointState.Taken;
                    other.transform.position = transform.position;
                }
            }
            Debug.Log($"{name}: Enter {other.name}");
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Ingredient>(out Ingredient ingredient))
            {
                if (ingredient.ingredientData == ingredientData)
                {
                    state = PointState.Free;
                }
            }
            Debug.Log($"{name}: Exit {other.name}");
        }
    }
}