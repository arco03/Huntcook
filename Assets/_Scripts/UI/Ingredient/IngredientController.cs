using System.Collections.Generic;
using _Scripts.Dish;
using _Scripts.Ingredient;
using UnityEngine;

namespace _Scripts.UI.Ingredient
{
    public class IngredientController : MonoBehaviour
    {
        [SerializeField] private IngredientView prefabView;
        [SerializeField] private GameObject backgroundImage;
        private List<IngredientView> _currentIngredients;

        public void Initialize()
        {
            // TODO: Animations
        }
        
        public void UpdateIngredients(DishData dishData)
        {
            foreach (IngredientData ingredientData in dishData.ingredientsList)
            {
                _currentIngredients = new List<IngredientView>();
                
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