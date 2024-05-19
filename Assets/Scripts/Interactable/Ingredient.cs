using UnityEngine;

namespace Interactable
{
    [RequireComponent((typeof(Rigidbody)))]
    public class Ingredient : MonoBehaviour, IDetector
    {
        //Dependencies
        
        public int id;
        private bool _isPicked;
        private Rigidbody _rb;
        [SerializeField] private GameObject character;
        


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.useGravity = false;
        }

        public void Interaction()
        {
            _isPicked = !_isPicked;
            if (_isPicked)
            {
                transform.SetParent(character.transform);
                transform.localPosition = new Vector3(0f, 0.161f, 1f);
                _rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                transform.SetParent(null);
                _rb.constraints = RigidbodyConstraints.None;
            }
            Debug.Log(id);
        }
    }
}
