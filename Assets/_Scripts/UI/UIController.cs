using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        //View
        [SerializeField] private UIView uiView;
        
        [Header("Timer Configurations")]
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private float timeElapse;

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