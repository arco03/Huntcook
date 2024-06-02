using UnityEngine;

namespace _Scripts.UI.Timer
{
    public class TimerView : MonoBehaviour
    {
        private int _minutes, _seconds;
        
        public string TimeFormat(float timeElapsed)
        {
            _minutes = (int)(timeElapsed / 60f);
            _seconds = (int)(timeElapsed - _minutes * 60f);
            
            return $"{_minutes:00}:{_seconds:00}";
        }
    }
}
