using Interactable;
using UnityEngine;

namespace ScriptTest
{
    public class AddMeat : MonoBehaviour,IDetector
    {
        [SerializeField] private int radius;
        [SerializeField] private LayerMask mask;
        [SerializeField] private GameObject meat;
        [SerializeField] private GameObject meatPeople;
        private void Usar()
        {

            Collider [] colliders = Physics.OverlapSphere(transform.position, radius,mask);
            
            foreach (Collider colliderDetected in colliders)
            { 
                if(!colliderDetected) continue;
                
                Debug.Log("entro");
                meat.gameObject.SetActive(true);
                meatPeople.gameObject.SetActive(false);
            }
            
        }
        public void Interaction()
        {
          Usar();
        }

       public void Update()
        {
            
            Usar();
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}