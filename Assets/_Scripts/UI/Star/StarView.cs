using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Star
{
    public class StarView : MonoBehaviour
    {
        [SerializeField] private Image[] starImages;
        [SerializeField] private Sprite emptyStar;
        [SerializeField] private Sprite filledStar;

        public void UpdateStars(int stars)
        {
            for (int i = 0; i < starImages.Length; i++)
            {
                if (i < stars)
                {
                    starImages[i].sprite = filledStar;
                }
                else
                {
                    starImages[i].sprite = emptyStar;
                }
            }
        }
    }
}