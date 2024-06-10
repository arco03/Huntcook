using UnityEngine.UI;
using UnityEngine;

namespace _Scripts.UI.Ingredient
{
    public class IngredientView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private GameObject ingredientContainer;

        public void Initialize()
        {
            ingredientContainer.SetActive(true);
        }

        public void SetIngredient(Sprite sprite)
        {
            image.sprite = sprite;
        }
        
        public void Close()
        {
            ingredientContainer.SetActive(false);
        }
    }
}