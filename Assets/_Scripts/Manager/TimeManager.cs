using System;
using UnityEngine;

namespace _Scripts.Manager
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float timeElapse;
        public UIManager uiManager;
        public static event Action OnTimeOver;
        
        private void Update()
        {
            timeElapse -= Time.deltaTime;
            uiManager.UpdateTime(timeElapse);

            if (timeElapse <= 0)
            {
                OnTimeOver?.Invoke();
            }
        }
    }
}