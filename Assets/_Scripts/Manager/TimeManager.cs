using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Manager
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float timeElapse;
        public UIManager uiManager;
        
        private void Update()
        {
            timeElapse -= Time.deltaTime;
            uiManager.UpdateTime(timeElapse);
            Debug.Log(timeElapse);
        }
    }
}