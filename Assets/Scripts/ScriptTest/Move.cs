using System;
using UnityEngine;

namespace ScriptTest
{
    [RequireComponent(typeof(Rigidbody))]
    public class Move : MonoBehaviour
    {
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;
        [SerializeField] private float speed;
        private Rigidbody _rb;
        private float _x, _y;

        //private void Start()
        //{
        //    _rb.useGravity = false;
        //}
       

        private void Update()
        {
            
            _x = Input.GetAxisRaw(horizontal);
            _y = Input.GetAxisRaw(vertical);
            
            
        }

        private void FixedUpdate()
        {
            transform.Translate(-_x*speed,0f,-_y*speed);
        }
        
    }
}
