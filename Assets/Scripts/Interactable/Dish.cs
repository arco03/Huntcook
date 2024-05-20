using System.Collections.Generic;
using Scriptable;
using UnityEngine;

namespace Interactable
{
    public class Dish : MonoBehaviour
    {
        [SerializeField] private List<Ingredient> ordenDeIngredientes = new List<Ingredient>();
        private int indiceActual = 0;
        private Ingredient _ingredientsData;
        private Queue<Ingredient> _recipeQueue;

        private List<Ingredient> _currentRecipe = new List<Ingredient>();

        //[SerializeField] private Ingredient ingredient;
        public float radius;
        public LayerMask mask;

        private void Start()
        {
             _currentRecipe = new List<Ingredient>();
             
        }

        private void Update()
        {
           Usar();

        }

        private void Usar()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, mask);

            foreach (Collider colliderDetected in colliders)
            {
                if (!colliderDetected) continue;

                Ingredient ingredient = colliderDetected.GetComponent<Ingredient>();

                if (ingredient)
                {
                    AddIngredient(ingredient);

                }


            }

        }

        public void AddIngredient(Ingredient ingredient)
        {

            if (indiceActual < ordenDeIngredientes.Count && ordenDeIngredientes[indiceActual] == ingredient &&
                ingredient.currentState == State.Captured)
            {
                AgregarIngredienteALaReceta(ingredient);
                // Avanza al siguiente ingrediente en la lista
                Debug.Log("indice" + indiceActual);
                indiceActual++;
            }


        }

        private void AgregarIngredienteALaReceta(Ingredient ingredient)
        {
            _currentRecipe.Add(ingredient);
            Debug.Log($"Se agregó el ingrediente con ID {ingredient.id} a la receta.");
            
            Debug.Log($"order {ordenDeIngredientes.Count} ");
            if (ingredient.id == ordenDeIngredientes.Count)
            {
                Debug.Log("¡Receta completa!");
                
                // Aquí puedes hacer algo cuando se completa la receta
            }
        }
    }
}

        

    

