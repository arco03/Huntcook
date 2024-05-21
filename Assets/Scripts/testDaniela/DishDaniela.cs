using System.Collections.Generic;
using Interactable;
using Scriptable;
using UnityEngine;

namespace testDaniela
{
    public class DishDaniela : MonoBehaviour
    {
        [SerializeField] private IngredientsData ingredientsData;
        private Queue<Ingredient> _recipeQueue;
        private List<Ingredient> _currentRecipe;
        //[SerializeField] private Ingredient ingredient;
        public float radius;
        public LayerMask mask;

        private void Start()
        {
            _recipeQueue = new Queue<Ingredient>(ingredientsData.prefabs);
            _currentRecipe = new List<Ingredient>();
        }
        private void Update()
        {
            Usar();
            //AddIngredient();
        }

        private void AddIngredient()
        {
            if (_recipeQueue.Count == 0)
            {
                Debug.Log("La cola esta vacía");
            }

            Ingredient nextIngredient = _recipeQueue.Peek();
            if (ingredientsData.id == nextIngredient.id)
            {
                _recipeQueue.Dequeue();
                Debug.Log($"se agregó {ingredientsData} a la receta");
                //Destroy(ingredient);
            }
            else
            {
                Debug.Log($"Incorrect ingredient. Expected {nextIngredient.id}.");
            }
        }

        private void Usar()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, mask);

            foreach (Collider colliderDetected in colliders)
            {
                if (!colliderDetected) continue;

                Debug.Log($"Entró ");
                
            }
            
        }
    }

}