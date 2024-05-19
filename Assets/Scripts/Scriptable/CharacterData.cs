using Playable;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(menuName = "Create Character", fileName = "Character")]
    public class CharacterData : ScriptableObject
    {
        public int id;
        public string playerName;
        public Sprite sprite;
        public Character playerPrefab;
        
        // public Character GetPrefab(int id)
        // {
        //     
        //    return  this.id = id;
        // }
    }
    
}