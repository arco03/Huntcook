using UnityEngine;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Control Settings")] 
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;
        [SerializeField] private Character character;
        
        private float _x, _z;
        

        private void Update()
        {
            _x = Input.GetAxisRaw(horizontal);
            _z = Input.GetAxisRaw(vertical);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                character.Use();
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
