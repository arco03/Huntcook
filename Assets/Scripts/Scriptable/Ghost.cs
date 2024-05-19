using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "Create Ghost", menuName = "Ghost")]
    public class Ghost : ScriptableObject
    {
        public int id;
        public string ghostName;
        public Sprite sprite;
        public Playable.GhostGame ghostPrefab;
    }
}