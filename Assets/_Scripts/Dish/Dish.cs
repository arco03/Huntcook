using System.Collections;
using System.Collections.Generic;
using _Scripts.Manager;
using JetBrains.Annotations;
using UnityEngine;

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
        
        private DishState _currentState;
        
        public DishState CurrentState
        {
            set
            {
                if (_currentState == value) return;
                
                _currentState = value;

                if (_currentState == DishState.Done)
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

        private void AddIngredient([NotNull] Ingredient.Ingredient ingredient)
        {
            if (!ingredient) return;
            
            if (ingredient.ingredientData == dishData.ingredientsList[_currentIngredient])
            {
                ingredientsPrefabs[_currentIngredient].SetActive(true);
                _currentIngredient++;
                if (ingredient) Destroy(ingredient.gameObject);
            }
        }

        private void CheckRecipeReady()
        {
            // If Recipe is ready then start the animation
            if (_currentIngredient >= dishData.ingredientsList.Count)
            {
                _anim.enabled = true;
                CurrentState = DishState.Done;
               // StartCoroutine(DishTimer());
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

        

    

