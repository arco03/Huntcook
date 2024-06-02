using _Scripts.Dish;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIData : MonoBehaviour
    {
        [SerializeField] private DishData dishData;
        [SerializeField] private TextMeshProUGUI textAmount;
        //[SerializeField] private Image recipeSprite;

        private void Awake()
        {
            dishData.amount = Random.Range(5, 10);
            textAmount.text = $"X {dishData.amount.ToString()}";
        }
        
    }
}