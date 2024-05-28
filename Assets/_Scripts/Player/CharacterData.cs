using UnityEngine;

namespace _Scripts.Player
{
    [CreateAssetMenu(menuName = "CharacterData", fileName = "CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public string playerName;
        public Sprite sprite;
    }
    
}