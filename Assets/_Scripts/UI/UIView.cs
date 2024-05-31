using System.Collections.Generic;
using _Scripts.Dish;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace _Scripts.UI
{
    public class UIView : MonoBehaviour
    {
        private int _minutes, _seconds;
        
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject uiTimer;
        [SerializeField] private GameObject uiRecipe;
        [SerializeField] private DishData amountTextList;
        [SerializeField] private string text;
        private int _randomAmount;
        public int index;
        
        public string GetStringTime(float timeElapsed)
        {
            _minutes = (int)(timeElapsed / 60f);
            _seconds = (int)(timeElapsed - _minutes * 60f);
            
            return $"{_minutes:00}:{_seconds:00}";
        }
        
        public void ShowGameOver() 
        { 
            gameOver.SetActive(true);
            uiTimer.SetActive(false);
            uiRecipe.SetActive(false);
        }
        
        public void DishAmount()
        {
            
                _randomAmount = Random.Range(1, 10);
                amountTextList.amount = _randomAmount;
                text = amountTextList.amount.ToString();
                // Debug.Log(text.amount);
                

                // index = _randomAmount;
           
            
            
        }

    }
}
