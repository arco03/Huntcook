using System;
using _Scripts.Dish;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.UI
{
    public class UIData : MonoBehaviour
    {
        [SerializeField] private DishData dishData;
        [SerializeField] private TextMeshProUGUI textAmount;
        //[SerializeField] private Image recipeSprite;

        private void Awake()
        {
            dishData.amount = Random.Range(1, 1);
        }

        private void Update()
        {
            textAmount.text = $"X {dishData.amount.ToString()}";
        }
    }
}