using System;
using UnityEngine;

namespace Interactable
{
    public class SpawnDish : MonoBehaviour
    {
        [SerializeField] private Dish spawner;

        private void Start()
        {
            Instantiate(spawner, this.transform.position, Quaternion.identity);
        }
    }
}