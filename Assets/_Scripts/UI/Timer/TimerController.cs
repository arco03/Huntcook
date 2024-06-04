using UnityEngine;

namespace _Scripts.UI.Timer
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private TimerView timerView;

        public void Initialize()
        {
            timerView.Initialize();
        }

        public void Close()
        {
            timerView.Close();
        }
        
        public void UpdateTime(float time)
        {
            timerView.SetTime(time);
        }
        
    }
}