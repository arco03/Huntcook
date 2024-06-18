using System;
using System.Collections;
using _Scripts.Audio;
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
        [SerializeField] private AudioManager audioManager;
        private Ingredient.Ingredient status;
        public bool tutorial;
        

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
                tutorial = true;
                character.Animator("Hand");
                
 
            }

            if (Input.GetKeyDown(KeyCode.E) && !character.isAttacking)
            {
                audioManager.PlaySfx("Knife");
                character.isAttacking = true;
                character.Animator("Attack");
            }
        }
        

        private void FixedUpdate()
        {
            character.Move(_x, _z);
            animator.SetFloat("Velx",_x);
            animator.SetFloat("Vely",_z);

        }


    }
}
