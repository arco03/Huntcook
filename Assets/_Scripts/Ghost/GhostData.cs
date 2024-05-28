using UnityEngine;

namespace _Scripts.Ghost
{
    [CreateAssetMenu(menuName = "GhostData", fileName = "GhostData")]
    public class GhostData : ScriptableObject
    {
        public string ghostName;
        public Sprite sprite;
    }
}