using System;
using System.Collections;
using UnityEngine;

namespace _Scripts.Ingredient
{
    public enum IngredientState
    {   
        Point,
        Captured,
    }
    
    [RequireComponent((typeof(Rigidbody)))]
    public class Ingredient : MonoBehaviour
    {
        public IngredientData ingredientData;
        public bool isPicked;
        private Rigidbody _rb;
        public IngredientState currentIngredientState;

        private Transform _owner;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            currentIngredientState = IngredientState.Point;
        }
        
        public void Interaction(Transform point)
        {
            if (_owner && _owner != point) return;
            
            isPicked = !isPicked;
            if (isPicked)
            {
                transform.SetParent(point);
                transform.localPosition = Vector3.zero;
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                currentIngredientState = IngredientState.Captured;
                _owner = point;
            }
            else
            {
                transform.SetParent(null);
                _rb.constraints = RigidbodyConstraints.None;
                currentIngredientState = IngredientState.Point;
                _owner = null;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                StartCoroutine(TimeDestroy());
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        IEnumerator TimeDestroy()
        {
                yield return new WaitForSeconds(5f);
                Destroy();
        }
    }
}
