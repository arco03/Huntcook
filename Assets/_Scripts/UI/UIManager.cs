using _Scripts.Dish;
using _Scripts.UI.Status;
using _Scripts.UI.Timer;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Timer Configurations")] 
        [SerializeField] private TimerView timerView;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private float timeElapse;
        
        [Header("Status Configurations")] 
        [SerializeField] private StatusController statusController;
        
        [Header("Recipe Configurations")]
        [SerializeField] private DishData dishData;
        
        private void Update()
        {
            timeElapse -= Time.deltaTime;

            if (timeElapse > 0)
                timerText.text = timerView.TimeFormat(timeElapse);
            else statusController.TimeOut();
            
        }
    }
}