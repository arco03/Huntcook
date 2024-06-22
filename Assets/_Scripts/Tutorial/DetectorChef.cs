using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Tutorial
{
    public class DetectorChef : MonoBehaviour
    {

        [SerializeField] private GameObject Enter;
        [SerializeField] private GameObject letter;

        private bool hasEntered = false;
        private bool hasE = false;
        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.CompareTag("Ingredients") && !hasEntered)
            {
                Enter.SetActive(true);
                StartCoroutine(Desactivate(Enter));
                hasEntered = true;
                
                
            }
            
            if (other.gameObject.CompareTag("Ghost") && !hasE)
            {
                letter.SetActive(true);
                StartCoroutine(Desactivate(letter));
                hasE = true;
                
                
            }
            
        }

        IEnumerator Desactivate(GameObject _name)
        {
            yield return new WaitForSeconds(5f);
            _name.SetActive(false);
        }
    }
}
