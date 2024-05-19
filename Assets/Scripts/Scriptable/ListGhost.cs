using System.Collections.Generic;
using Playable;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "List Ghost", menuName = "Ghosts")]
    public class ListGhost : ScriptableObject
    {
        [HideInInspector] public int id;
        public List<GhostGame> ghost;
        
        public GhostGame GetPrefab(int id)
        {
            this.id = id;
            return ghost.Find(enemy => enemy.id == id);

        }
    }
}