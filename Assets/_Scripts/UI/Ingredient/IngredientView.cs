using UnityEngine.UI;
using UnityEngine;

namespace _Scripts.UI.Ingredient
{
    public class IngredientView : MonoBehaviour
    {
        [SerializeField] private Image ingredientImage;


        public void Initialize(Sprite sprite, Transform parent)
        {
            ingredientImage.sprite = sprite;
            gameObject.transform.SetParent(parent);
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}