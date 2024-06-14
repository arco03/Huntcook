using UnityEngine;

namespace _Scripts.Tutorial
{
    public class DetectorChef : MonoBehaviour
    {
        public bool detector;
        public bool detectorGhost;
        public bool detectorPlate;
        

        

        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Ingredients"))
            {
                detector = true;
            }

            if (other.gameObject.CompareTag("Ghost"))
            {   
               detectorGhost = true;
            }

            if (other.gameObject.CompareTag("DishPoint"))
            {
                detectorPlate = true;

            }
        }
    }
}