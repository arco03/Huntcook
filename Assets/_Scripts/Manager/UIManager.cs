using _Scripts.Dish;
using _Scripts.UI.Ingredient;
using _Scripts.UI.Recipe;
using _Scripts.UI.Timer;
using UnityEngine;

namespace _Scripts.Manager
{
    public class UIManager : MonoBehaviour
    {
        [Header("Timer Configurations")] 
        [SerializeField] private TimerController timerController;
        
        [Header("Recipe Configurations")]
        [SerializeField] private RecipeController recipeController;

        [Header("Ingredient List Configurations")]
        [SerializeField] private IngredientController ingredientListController;


        public void OnEnable()
        {
            timerController.Initialize();
            recipeController.Initialize();
            ingredientListController.Initialize();
        }

        public void UpdateTime(float timeElapse)
        {
            timerController.UpdateTime(timeElapse);
        }

        public void UpdateDish(DishData data)
        {
            recipeController.UpdateDish(data);
            ingredientListController.ClearIngredients();
            ingredientListController.UpdateIngredients(data);
        }

        public void OnDisable()
        {
            timerController.Close();
            recipeController.Close();
        }
    }
}
