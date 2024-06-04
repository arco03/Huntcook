using _Scripts.Dish;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace _Scripts.UI.Recipe
{
    public class RecipeView : MonoBehaviour
    {
        [SerializeField] private Sprite image;
        [SerializeField] private DishData dishData;

        public void Awake()
        {
            image = dishData.image;
        }
    }
}
