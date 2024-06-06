using _Scripts.Dish;
using _Scripts.UI.Recipe;
using _Scripts.UI.State;
using _Scripts.UI.Timer;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Timer Configurations")] 
        [SerializeField] private TimerController timerController;
        
        [Header("Recipe Configurations")]
        [SerializeField] private RecipeController recipeController;

        public void OnEnable()
        {
            timerController.Initialize();
            recipeController.Initialize();
        }

        public void UpdateTime(float timeElapse)
        {
            timerController.UpdateTime(timeElapse);
        }

        public void UpdateDish(Sprite sprite, int amount)
        {
            recipeController.UpdateDish(sprite, amount);
        }
        
        public void OnDisable()
        {
            timerController.Close();
            recipeController.Close();
        }
    }
}
