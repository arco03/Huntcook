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

        public void UpdateDish(Sprite sprite, int amount, string nameRecipe)
        {
            recipeView.SetDish(sprite, amount, nameRecipe);
        }
        
    }
    
}