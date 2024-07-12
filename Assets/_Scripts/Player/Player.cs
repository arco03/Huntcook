using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Control Settings")] 
        //[SerializeField] private string horizontal;
        //[SerializeField] private string vertical;
        [SerializeField] private Character character;
        [SerializeField] private Animator animator;
        private Ingredient.Ingredient status;
        public bool tutorial;
        public PlayerInput playerInput;
        //private float _x, _z;
        private Vector2 _movementInputMove;
        

        private void Start()
        {
            status = FindObjectOfType<Ingredient.Ingredient>();
            playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            _movementInputMove = playerInput.actions["Move"].ReadValue<Vector2>();


            if (playerInput.actions["Take"].WasPressedThisFrame())
            {
                tutorial = true;
                character.Animator("Hand");
            }

            if (playerInput.actions["Attack"].WasPressedThisFrame() && !character.isAttacking)
            {
                //AudioManager.instance.PlaySfx("Knife");
                character.isAttacking = true;
                character.Animator("Attack");
            }
        }
        

        private void FixedUpdate()
        {
            character.Move(_movementInputMove);
            animator.SetFloat("Velx",_movementInputMove.x);
            animator.SetFloat("Vely",_movementInputMove.y);

        }


    }
}
