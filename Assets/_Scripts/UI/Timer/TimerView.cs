 using TMPro;
 using UnityEngine;

namespace _Scripts.UI.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text timeText;
        
        private int _minutes, _seconds;

        public void Initialize()
        {
            timeText.gameObject.SetActive(true);
        }

        public void Close()
        {
            timeText.gameObject.SetActive(false);
        }
        
        public void SetTime(float timeElapsed)
        {
            _minutes = (int)(timeElapsed / 60f);
            _seconds = (int)(timeElapsed - _minutes * 60f);
            
            string timeFormat = $"{_minutes:00}:{_seconds:00}";
            timeText.text = timeFormat;
        }
    }
}
