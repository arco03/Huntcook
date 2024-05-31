using System;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIView uiView;
        
        [Header("Timer Configurations")]
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private float timeElapse;

        private void Start()
        {
            uiView.DishAmount();
        }

        private void Update()
        {
            timeElapse -= Time.deltaTime;
            
            if (timeElapse > 0)
                textMesh.text = uiView.GetStringTime(timeElapse);
            else TimeOut();
        }

        private void TimeOut()
        {
                Time.timeScale = 0f;
                uiView.ShowGameOver();
        }
    }
}