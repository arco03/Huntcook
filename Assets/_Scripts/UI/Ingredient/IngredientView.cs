using UnityEngine.UI;
using UnityEngine;

namespace _Scripts.UI.Ingredient
{
    public class IngredientView : MonoBehaviour
    {
        [SerializeField] private Image ingredientImage;
        [SerializeField] private GameObject backgroundImage;

        public void Initialize(Sprite sprite, Transform parent)
        {
            ingredientImage.sprite = sprite;
            gameObject.transform.SetParent(parent);
            backgroundImage.SetActive(true);
        }

        public void Close()
        {
            if(!gameObject) 
                Destroy(gameObject);
            
        }

        public void CloseView()
        {
            backgroundImage.SetActive(false);
        }
    }
}