using UnityEngine;

namespace Playable
{
    public class Player : MonoBehaviour
    {
        [Header("Control Settings")] 
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;
        
        [SerializeField] private Character character;
        // [SerializeField] private GameObject light;
        private float _x, _z;
        

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
        
    }
}
