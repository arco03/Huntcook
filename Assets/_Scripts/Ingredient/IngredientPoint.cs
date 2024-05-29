using System;
using UnityEngine;

namespace _Scripts.Ingredient
{
    [Serializable]
    public enum PointState
    {
        Free,
        Taken,
        // None,
    }
    
    public class IngredientPoint : MonoBehaviour
    {
        public  PointState state;
        public IngredientData ingredientData;
        // private bool _detected = false;     

        private void Start()
        {
            
            GetComponent<MeshRenderer>().enabled = false;
            
        }

        public void Update()
        {
            // if (_detected)
            // {
            //     state == PointState.None;
            // }

        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Ingredient>(out Ingredient ingredient))
            {
                if (ingredient.ingredientData == ingredientData)
                {
                    state = PointState.Taken;
                    // _detected = true;
                    other.transform.position = transform.position;
                }
            }
            Debug.Log($"{name}: Enter {other.name}");
            
        }

        public void OnTriggerExit(Collider other)
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