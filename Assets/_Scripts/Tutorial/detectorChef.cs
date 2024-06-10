using System;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Tutorial
{
    public class detectorChef : MonoBehaviour
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