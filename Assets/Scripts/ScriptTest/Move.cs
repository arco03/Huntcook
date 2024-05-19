using UnityEngine;

namespace ScriptTest
{
    [RequireComponent(typeof(Rigidbody))]
    public class Move : MonoBehaviour
    {
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;
        [SerializeField] private float speed;
        [SerializeField] private float rSpeed = 100f;
        private Rigidbody _rb;
        private float _x, _z;
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _x = Input.GetAxisRaw(horizontal);
            _z = Input.GetAxisRaw(vertical);
        }

        private void FixedUpdate()
        {
            Vector3 forwardMovement = transform.forward * (_z * speed);

            _rb.velocity = new Vector3(forwardMovement.x, _rb.velocity.y, forwardMovement.z);
            
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * (_x * rSpeed * Time.fixedDeltaTime));
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }
        
    }
}
