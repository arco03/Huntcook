using System.Collections;
using System.Collections.Generic;
using Scriptable;
using UnityEngine;

namespace Interactable
{
    public class Dish : MonoBehaviour
    {
        [SerializeField] private DishData recipeData;
        [SerializeField] private List<GameObject> ingredientsPrefabs;
        
        private Animator _anim;
        private int _currentIngredient;
        
        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _anim.enabled = false;
        }

        private void Start()
        {
            foreach (GameObject prefab in ingredientsPrefabs)
            {
                prefab.SetActive(false);
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            // Check the same Ingredient ID from the list of ingredients
            if ( ingredient.ingredientData == recipeData.ingredientsList[_currentIngredient] )
            {
                ingredientsPrefabs[_currentIngredient].SetActive(true);
                _currentIngredient++;
                if (ingredient) Destroy(ingredient.gameObject);
            }
        }

        public void CheckRecipeReady()
        {
            // If Recipe is ready then start the animation
            if (_currentIngredient >= recipeData.ingredientsList.Count)
            {
                _anim.enabled = true;
                StartCoroutine(Timer());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Ingredient ingredient = other.GetComponent<Ingredient>();
            AddIngredient(ingredient);
            CheckRecipeReady();
        }

        IEnumerator Timer()
        {
            yield return new WaitForSeconds(5f);
            _anim.SetTrigger("Activate");
        }
    }
}

        

    

