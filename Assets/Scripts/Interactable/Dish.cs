using System.Collections.Generic;
using Scriptable;
using UnityEngine;

namespace Interactable
{
    public class Dish : MonoBehaviour
    {
        [SerializeField] private IngredientsData _ingredientsData;
        private Queue<Ingredient> _recipeQueue;
        private List<Ingredient> _currentRecipe;
        //[SerializeField] private Ingredient ingredient;
        public float radius;
        public LayerMask mask;

        private void Start()
        {
            _recipeQueue = new Queue<Ingredient>(_ingredientsData.prefabs);
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
            if (_ingredientsData.GetPrefab() == nextIngredient.id)
            {
                _recipeQueue.Dequeue();
                Debug.Log($"se agregó {_ingredientsData} a la receta");
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