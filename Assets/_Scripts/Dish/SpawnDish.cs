﻿using UnityEngine;

namespace _Scripts.Dish
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
                // Instantiate(spawner, this.transform.position, Quaternion.identity);
                Debug.Log($"Plato con estado {spawner.currentState}");
            }
        }
        
        
    }
}