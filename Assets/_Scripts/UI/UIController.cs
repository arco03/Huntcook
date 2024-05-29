using TMPro;
using UnityEngine;


namespace _Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIView uiView;
        
        [Header("Timer Configurations")]
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private GameObject uiTimer;
        [SerializeField] private float timeElapse;

        [SerializeField] private GameObject uiRecipe;

        private void Update()
        {
            timeElapse -= Time.deltaTime;
            
            if(timeElapse > 0)
            {
                textMesh.text = uiView.GetStringTime(timeElapse);
            }
            else TimeOut();
        }

        private void TimeOut()
        {
                Time.timeScale = 0f;
                uiTimer.SetActive(false);
                uiRecipe.SetActive(false);
                uiView.ShowGameOver();
        }
    }
}