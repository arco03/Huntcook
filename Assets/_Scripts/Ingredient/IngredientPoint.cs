using System;
using UnityEngine;

namespace _Scripts.Ingredient
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

        private void Start()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        public void SetUp(IngredientData data)
        {
            ingredientData = data;
        }
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Ingredient>(out Ingredient ingredient))
            {
                if (ingredient.ingredientData == ingredientData && ingredient.currentIngredientState == IngredientState.Point )
                {
                    state = PointState.Taken;
                    ingredient.transform.position = transform.position;
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Ingredient>(out Ingredient ingredient))
            {
                if (ingredient.ingredientData == ingredientData && ingredient.isPicked)
                {
                    state = PointState.Free;
                }
            }
        }

    }
}