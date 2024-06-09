using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
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

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
    
                StartCoroutine(timeDestroy());
                    
                
               
            }
            
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        IEnumerator timeDestroy()
        {

                yield return new WaitForSeconds(5f);
                Destroy();
        }


    }
}
