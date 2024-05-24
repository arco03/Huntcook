using System;
using UnityEngine;

namespace Interactable
{
    public class SpawnDish : MonoBehaviour
    {
        [SerializeField] private Dish spawner;
        [SerializeField] private float repeatingTime;
        private void Start()
        {
            Instantiate(spawner, this.transform.position, Quaternion.identity);
            InvokeRepeating("Respawn", repeatingTime, repeatingTime);
        }
        
        public void Respawn()
        {
            if (spawner.currentState == DishState.Done)
            {
                Instantiate(spawner, this.transform.position, Quaternion.identity);
            }
        }
        
        
    }
}