using System.Collections.Generic;
using _Scripts.Dish;
using _Scripts.Ingredient;
using UnityEngine;

namespace _Scripts.UI.Ingredient
{
    public class IngredientController : MonoBehaviour
    {
        [SerializeField] private IngredientView prefabView;
        [SerializeField] public GameObject backgroundImage;
        private List<IngredientView> _currentIngredients;
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        public void Initialize()
        {
            // TODO: Animations
            _currentIngredients = new List<IngredientView>();
        }

        public void ClearIngredients()
        {
            // foreach (IngredientView ingredient in _currentIngredients)
            // {
            //     ingredient.Close();
            // }
            _currentIngredients.Clear();
        }
        
        public void UpdateIngredients(DishData dishData)
        {
            foreach (IngredientData ingredientData in dishData.ingredientsList)
            {
                // TODO: Factory for ingredients UI
                var ingredientView = Instantiate(prefabView).GetComponent<IngredientView>();
                ingredientView.Initialize(ingredientData.sprite, backgroundImage.transform);
                
                _currentIngredients.Add(ingredientView);
            }
        }

        public void Close()
        {
            foreach (IngredientView currentIngredient in _currentIngredients)
            {
                currentIngredient.Close();
            }
        }

    }
}