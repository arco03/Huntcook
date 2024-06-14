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
        [SerializeField] private TMP_Text nameText;
        
        public void Initialize()
        {
            recipeContainer.SetActive(true);
        }
        
        public void SetDish(Sprite sprite, int amount, string nameRecipe)
        {
            image.sprite = sprite;
            amountText.text = amount.ToString();
            nameText.text = nameRecipe;
        }

        public void Close()
        {
            recipeContainer.SetActive(false);
        }

    }
}
