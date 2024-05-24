using System;
using Scriptable;
using UnityEngine;

namespace Playable
{
    [Serializable]
    public class Ghost : MonoBehaviour
    {
        public GhostData ghostData;
        public Transform target;
        
        private void Update()
        {
            // Vector3.MoveTowards(transform.position, target.position, 0.5f);
        }
    }
}