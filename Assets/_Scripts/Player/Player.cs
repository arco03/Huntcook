using System;
using System.Collections;
using _Scripts.Ingredient;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Control Settings")] 
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;
        [SerializeField] private Character character;
        private Ingredient.Ingredient status;
      
        private float _x, _z;

        private void Start()
        {
            status = FindObjectOfType<Ingredient.Ingredient>();
        }

        private void Update()
        {
            _x = Input.GetAxisRaw(horizontal);
            _z = Input.GetAxisRaw(vertical);
           
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                character.Animator();
                
            }

            if (Input.GetKeyDown(KeyCode.E) && !character.isAttacking)
            {
                character.isAttacking = true;
                character.Attack();
            }
            
        }

        private void FixedUpdate()
        {
            character.Move(_x, _z);
        }


    }
}
