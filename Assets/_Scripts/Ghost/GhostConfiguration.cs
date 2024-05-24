using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Ghost
{
    [CreateAssetMenu(menuName = "GhostConfiguration", fileName = "GhostConfiguration")]
    public class GhostConfiguration : ScriptableObject
    {
        public List<Ghost> ghosts;
        
        public Ghost GetPrefab(GhostData id)
        {
            return ghosts.Find(ghost => ghost.ghostData == id);
        }
    }
}