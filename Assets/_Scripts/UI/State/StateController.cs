using _Scripts.UI.Star;
using UnityEngine;

namespace _Scripts.UI.State
{
    public class StateController : MonoBehaviour
    {
        [SerializeField] private StateView statusView;
        [SerializeField] private StarController starController;
        
        public void TimeOut()
        {
            statusView.ShowGameOver();
        }
        public void Win()
        {
            statusView.ShowWin();
            starController.CompletedLevel();
        }
    }
}