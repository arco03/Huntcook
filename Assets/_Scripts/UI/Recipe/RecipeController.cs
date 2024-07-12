using _Scripts.Dish;
using UnityEngine;

namespace _Scripts.UI.Recipe
{
    public class RecipeController : MonoBehaviour
    {
        [SerializeField] private RecipeView recipeView;

        public void Initialize()
        {
            recipeView.Initialize();
        }

        public void Close()
        {
            recipeView.Close();
        }
        
        public void UpdateDish(DishData data)
        {
            recipeView.SetDish(data.image, data.amount, data.recipeName);
        }
        
    }
    
}