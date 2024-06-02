using UnityEngine;

namespace _Scripts.UI.Status
{
    public class StatusController : MonoBehaviour
    {
        [SerializeField] private StatusView statusView;

        public void TimeOut()
        {
                Time.timeScale = 0f;
                statusView.ShowGameOver();
        }
    }
}