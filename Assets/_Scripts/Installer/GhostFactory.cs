using Playable;
using Scriptable;


namespace Installer
{
    public class GhostFactory
    {
        private readonly GhostConfiguration _config;
        
        public GhostFactory(GhostConfiguration config)
        {
            _config = config;
        }
        
        public Ghost Create(GhostData data)
        { 
            Ghost prefabToCreate = _config.GetPrefab(data);
            return UnityEngine.Object.Instantiate(prefabToCreate);
        }
    }
}