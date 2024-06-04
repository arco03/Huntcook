using _Scripts.Dish;
using _Scripts.UI.Recipe;
using _Scripts.UI.Status;
using _Scripts.UI.Timer;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Timer Configurations")] 
        [SerializeField] private TimerController timerController;
        
        [Header("Status Configurations")] 
        [SerializeField] private StatusController statusController;
        
        [Header("Recipe Configurations")]
        [SerializeField] private DishData dishData;
        [SerializeField] private RecipeController recipeController;

        private void OnEnable()
        {
            timerController.Initialize();
        }

        private void UpdateTime(float timeElapse)
        {
            timerController.UpdateTime(timeElapse);
        }

        private void OnDisable()
        {
            timerController.Close();
        }
    }
}