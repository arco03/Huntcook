﻿using _Scripts.Installer;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Ingredient
{
    public enum State
    {   
        Point,
        Captured,
         
    }
    [RequireComponent((typeof(Rigidbody)))]
    public class Ingredient : MonoBehaviour, IDetector
    {
        public IngredientData ingredientData;
        
        private bool _isPicked;
        private Rigidbody _rb;
        public State currentState;
        public Renderer material ;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            currentState = State.Point;
        }
        
        public void Interaction(Transform character)
        {
            _isPicked = !_isPicked;
            if (_isPicked)
            {
                transform.SetParent(character);
                transform.localPosition = new Vector3(0.0055999998f,2.53386006e-08f,0f);
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                currentState = State.Captured;
            }
            else
            {
                transform.SetParent(null);
                _rb.constraints = RigidbodyConstraints.None;
                currentState = State.Point;
            }
        
        }

        public void Destroy()
        {
            Debug.Log(name);
            Destroy(gameObject);
        }
        
    }
}
