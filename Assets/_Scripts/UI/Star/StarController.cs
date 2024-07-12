using _Scripts.Manager;
using UnityEngine;

namespace _Scripts.UI.Star
{
    public class StarController : MonoBehaviour
    {
        private StarManager _starManager;
        [SerializeField] private StarView starView;
        [SerializeField] private TimeManager timeManager;
        [SerializeField] private float threeStar;
        [SerializeField] private float twoStar;
        
        public void Awake()
        {
            _starManager = new StarManager(threeStar, twoStar);
        }

        public void CompletedLevel()
        {
            var timeElapse = timeManager.timeElapse;
            Debug.Log("Time: " +timeElapse);
            _starManager.CalculateStars(timeElapse);
            starView.UpdateStars(_starManager.TotalStars);
        }
    }
}