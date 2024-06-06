using UnityEngine;

namespace _Scripts.UI.State
{
    public class StateController : MonoBehaviour
    {
        [SerializeField] private StateView statusView;
        
        public void TimeOut()
        {
            statusView.ShowGameOver();
        }
        public void Win()
        {
            statusView.ShowWin();
        }
    }
}