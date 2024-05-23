using System;
using System.Collections;
using System.Collections.Generic;
using Installer;
using Scriptable;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactable
{
    public class Dish : MonoBehaviour
    {
        //[SerializeField] private List<Ingredient> ordenDeIngredientes = new List<Ingredient>();
        //[SerializeField] List<Ingredient> _currentRecipe = new List<Ingredient>();

        //[SerializeField] private Ingredient ingredient;
        // private IngredientsData _ingrent;
        
        // private void Start()
        // {
        //     _ingrent = FindObjectOfType<IngredientsData>();
        //     //      _currentRecipe = new List<Ingredient>();
        //     //      
        // }
        
        private int indiceActual = 0;
        private Ingredient _ingredientsData;

               
        private Queue<Ingredient> _recipeQueue;

        public float radius;
        public LayerMask mask;
        private FactoryRecipe _food;
        [SerializeField] private RecipeData configFood;
        [SerializeField] private Animator anim;


        private void Awake()
        {
            _food = new FactoryRecipe(configFood);
            
        }

        private void Start()
        {
            anim = GetComponent<Animator>();
            anim.enabled = false;
        }

        private void Update()
        {
            Usar();

        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Usar()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, mask);

            foreach (Collider colliderDetected in colliders)
            {
                if (!colliderDetected) continue;

                Ingredient ingredient = colliderDetected.GetComponent<Ingredient>();


                // if (ingredient.id == indiceActual)
                // {
                //     // Debug.Log("ingrediente {_ingrent}");
                //     // if (ingredient.id == _ingrent.id)
                //     // {
                //         Debug.Log("entre");
                //     // }
                AddIngredient(ingredient);
                //
                // }


            }

        }
        //
         public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient.id == indiceActual && indiceActual<configFood.recipeList.Count)
            {
                if (ingredient!= null) Destroy(ingredient.gameObject);
                
                Ingredient food = _food.Create(indiceActual);
                food.transform.SetParent(this.transform);
                food.transform.localPosition = new Vector3(0f, 0f + indiceActual * -4 , 0f);
                indiceActual++;
            }

            if (indiceActual == configFood.recipeList.Count)
            {
                anim.enabled = true;
                Debug.Log("Receta lista");
                StartCoroutine(Timer());

            }
 
            
        }
        IEnumerator Timer()
        {
            
            yield return new WaitForSeconds(5f);
            anim.SetTrigger("Activate");
            
        }


         
    //     // if (/*indiceActual < ordenDeIngredientes.Count*/ ordenDeIngredientes[indiceActual] == ingredient)
        //     // {
        //     //     // AgregarIngredienteALaReceta(ingredient);
        //     //     // Avanza al siguiente ingrediente en la lista
        //     //     Debug.Log("indice" + indiceActual);
        //     //     indiceActual++;
        //     // }
        //
        //    
        // }
        //
        // private void AgregarIngredienteALaReceta(Ingredient ingredient)
        // {
        //     _currentRecipe.Add(ingredient);
        //     Debug.Log($"Se agregó el ingrediente con ID {ingredient.id} a la receta.");
        //     
        //     Debug.Log($"order {ordenDeIngredientes.Count} ");
        //     
        //     if (ingredient.id == ordenDeIngredientes.Count)
        //     {
        //         Debug.Log("¡Receta completa!");
        //         
        //         // Aquí puedes hacer algo cuando se completa la receta
        //     }
        // }
    }
}

        

    

