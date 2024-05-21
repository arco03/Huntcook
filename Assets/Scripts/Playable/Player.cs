using UnityEngine;

namespace Playable
{
    public class Player : MonoBehaviour
    {
        [Header("Control Settings")] 
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;

        [Header("Character Settings")] 
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Character character;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask mask;
        
        private float _x, _z;

        private void Start()
        {
            character.CharacterSetUp(speed,rotationSpeed, radius, mask);
           
        }

        private void Update()
        {
            _x = Input.GetAxisRaw(horizontal);
            _z = Input.GetAxisRaw(vertical);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                character.Use();
            }
        }

        private void FixedUpdate()
        {
            character.Move(_x, _z);
        }

        // void OnDrawGizmosSelected()
        // {
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawWireSphere(transform.position, radius);
        // }
    }
}
