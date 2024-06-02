using System;
using System.Collections;
using _Scripts.Ingredient;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Control Settings")] 
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;
        [SerializeField] private Character character;
        [SerializeField] private Animator animator;
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

            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetBool("Open",true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Close",true);
            }
            
        }
        

        private void FixedUpdate()
        {
            character.Move(_x, _z);
        }


    }
}
