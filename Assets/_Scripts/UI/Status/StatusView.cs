using UnityEngine;

namespace _Scripts.UI.Status
{
    public class StatusView : MonoBehaviour
    { 
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject uiTimer;
        [SerializeField] private GameObject uiRecipe;
        
        public void ShowGameOver() 
        { 
            gameOverPanel.SetActive(true);
            uiTimer.SetActive(false);
            uiRecipe.SetActive(false);
        }

        public void ShowWin()
        {
            winPanel.SetActive(true);
            uiTimer.SetActive(false);
            uiRecipe.SetActive(false);
        }

    }
}