using System.Collections;
using System.Collections.Generic;
using _Scripts.Installer;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Dish
{
    public enum DishState
    {
        Clean,
        Done,
    }
    public class Dish : MonoBehaviour
    {
        public DishData dishData;
        [SerializeField] private List<GameObject> ingredientsPrefabs;
       
        private Animator _anim;
        private int _currentIngredient;
        
        private DishState currentState;

        public DishState CurrentState
        {
            set
            {
                if (currentState == value) return;
                
                currentState = value;

                if (currentState == DishState.Done)
                {
                    DishManager.DishReady(dishData);
                }
            }
        }
        

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _anim.enabled = false;
        }

        private void Start()
        {
            CurrentState = DishState.Clean;
            foreach (GameObject prefab in ingredientsPrefabs)
            {
                prefab.SetActive(false);
            }
        }

        public void AddIngredient(Ingredient.Ingredient ingredient)
        {
            // Check the same Ingredient ID from the list of ingredients
            if ( ingredient.ingredientData == dishData.ingredientsList[_currentIngredient] )
            {
                ingredientsPrefabs[_currentIngredient].SetActive(true);
                _currentIngredient++;
                if (ingredient) Destroy(ingredient.gameObject);
            }
        }

        public void CheckRecipeReady()
        {
            // If Recipe is ready then start the animation
            if (_currentIngredient >= dishData.ingredientsList.Count)
            {
                _anim.enabled = true;
                CurrentState = DishState.Done;
                StartCoroutine(DishTimer());
                dishData.amount -= 1;
                Debug.Log($"Current amount {dishData.amount}");
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            Ingredient.Ingredient ingredient = other.GetComponent<Ingredient.Ingredient>();
            AddIngredient(ingredient);
            CheckRecipeReady();
        }


        IEnumerator DishTimer()
        {
            yield return new WaitForSeconds(5f);
            _anim.SetTrigger("Activate");
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }
}

        

    

