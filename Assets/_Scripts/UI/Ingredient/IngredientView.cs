using UnityEngine.UI;
using UnityEngine;

namespace _Scripts.UI.Ingredient
{
    public class IngredientView : MonoBehaviour
    {
        public Image ingredientImage;
        [SerializeField] private Image backgroundImage;

        public void Initialize(Sprite sprite, Transform parent)
        {
            ingredientImage.sprite = sprite;
            gameObject.transform.SetParent(parent);
        }

        public void Close()
        {
            if(gameObject) 
                Destroy(gameObject);
        }

        public void CloseView()
        {
            //backgroundImage.SetActive(false);
        }
    }
}