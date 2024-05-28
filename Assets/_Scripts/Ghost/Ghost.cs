using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Ghost
{
    [Serializable]
    public class Ghost : MonoBehaviour
    {
        public GhostData ghostData;
        public Transform target;
        
       
        private int _maxHealth;
        private int _currentHealth;

        public void Start()
        {
            _maxHealth = 3;
            _currentHealth = _maxHealth;
        }



        public void TakeDamage(int damage)
        {
            
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Debug.Log("Ghost Destroyed");
                Destroy(gameObject);
            }
            
        }
        
        
    }
}