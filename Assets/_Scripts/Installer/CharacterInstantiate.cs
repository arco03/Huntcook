using System;
using Playable;
using Unity.Mathematics;
using UnityEngine;

namespace Installer
{
    public class CharacterInstantiate : MonoBehaviour
    {
        [SerializeField] private Character characterPrefab;
        private bool _hasInstantiate = false;

        private void Awake()
        {
            if (!_hasInstantiate)
            {
                Instantiate(characterPrefab, transform.position, quaternion.identity);
                _hasInstantiate = true;
            }
            else
            {
                Debug.LogError("El objeto ya está instanciado");
            }
        }
    }
}