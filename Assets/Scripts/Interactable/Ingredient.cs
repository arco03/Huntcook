using System;
using Installer;
using Playable;
using UnityEngine;

namespace Interactable
{
    public enum State
    {   
        Point,
        Captured,
         
    }
    [RequireComponent((typeof(Rigidbody)))]
    public class Ingredient : MonoBehaviour, IDetector
    {
        //Dependencies

        private static int nextID = 0;
        private bool _isPicked;
        private Rigidbody _rb;
        private Character character;
        public State currentState;
        public int id;

        private void Awake()
        {
            id = nextID;
            nextID++;
            _rb = GetComponent<Rigidbody>();
            _rb.useGravity = false;
            currentState = State.Point;
            character = FindObjectOfType<Character>();
        }

        public void Interaction()
        {
            _isPicked = !_isPicked;
            if (_isPicked)
            {
                transform.SetParent(character.transform);
                transform.localPosition = new Vector3(0f, 0.161f, 1f);
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                currentState = State.Captured;
            }
            else
            {
                transform.SetParent(null);
                _rb.constraints = RigidbodyConstraints.None;
                
            }
        
        }

    }
}
