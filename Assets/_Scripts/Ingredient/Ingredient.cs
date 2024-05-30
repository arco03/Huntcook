﻿using _Scripts.Installer;
using UnityEngine;

namespace _Scripts.Ingredient
{
    public enum IngredientState
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
        public IngredientState currentIngredientState;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            currentIngredientState = IngredientState.Point;
        }
        
        public void Interaction(Transform point)
        {
            _isPicked = !_isPicked;
            if (_isPicked)
            {
                transform.SetParent(point);
                transform.localPosition = Vector3.zero;
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                currentIngredientState = IngredientState.Captured;
            }
            else
            {
                transform.SetParent(null);
                _rb.constraints = RigidbodyConstraints.None;
                currentIngredientState = IngredientState.Point;
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
    }
}
