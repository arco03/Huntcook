using _Scripts.Dish;
using _Scripts.UI.Status;
using UnityEngine;

namespace _Scripts.UI.Recipe
{
    public class RecipeController : MonoBehaviour
    {
        [Header("Status Configurations")] 
        [SerializeField] private StatusController statusController;
        
        [Header("Recipe Configurations")]
        [SerializeField] private DishData dishData;

        private void Update()
        {
            if(dishData.amount == 0) 
                statusController.Win();
        }

        
    }
    
}