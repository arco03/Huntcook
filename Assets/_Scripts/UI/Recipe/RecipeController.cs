using _Scripts.Dish;
using UnityEngine;

namespace _Scripts.UI.Recipe
{
    public class RecipeController : MonoBehaviour
    {
        [SerializeField] private RecipeView recipeView;
        [SerializeField] private DishData dishData;

        public void Initialize()
        {
            recipeView.Initialize();
        }

        public void Close()
        {
            recipeView.Close();
        }

        public void UpdateDish(Sprite sprite, int amount)
        {
            recipeView.SetDish(sprite, amount);
        }
        
        
        // private void Update()
        // {
        //      RecipeReady();
        // }

        // private void RecipeReady()
        // {
        //     if(dishData.amount == 0) 
        //         stateController.Win();
        // }
        
    }
    
}