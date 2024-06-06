using _Scripts.Dish;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Recipe
{
    public class RecipeView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private GameObject recipeContainer;
        
        public void Initialize()
        {
            recipeContainer.SetActive(true);
        }
        
        public void SetDish(Sprite sprite, int amount)
        {
            image.sprite = sprite;
            amountText.text = amount.ToString();
        }

        public void Close()
        {
            recipeContainer.SetActive(false);
        }

    }
}
