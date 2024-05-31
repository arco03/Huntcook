using UnityEngine;

namespace _Scripts.UI
{
    public class UIView : MonoBehaviour
    {
        private int _minutes, _seconds;
        
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject uiTimer;
        [SerializeField] private GameObject uiRecipe;
        
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
        
        
    }
}
