using UnityEngine;

namespace _Scripts.UI.State
{
    public class StateView : MonoBehaviour
    { 
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private UIManager uIManager;
        [SerializeField] private GameObject uiRecipe;
        
        public void ShowGameOver() 
        { 
            Time.timeScale = 0f; 
            gameOverPanel.SetActive(true);
            uIManager.OnDisable();
            uiRecipe.SetActive(false);
        }

        public void ShowWin()
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
            uIManager.OnDisable();
            uiRecipe.SetActive(false);
        }

    }
}