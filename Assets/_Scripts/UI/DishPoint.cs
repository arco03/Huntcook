using UnityEngine;

namespace _Scripts.UI
{
    public class DishPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DishPoint"))
            {
                Debug.Log("Colisionó con el punto del plato que bendición");
            }
        }
    }
}