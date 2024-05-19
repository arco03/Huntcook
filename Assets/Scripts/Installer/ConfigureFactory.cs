using Playable;
using Scriptable;


namespace Installer
{
    public class ConfigureFactory
    {
        private readonly ListGhost _config;
        
        public ConfigureFactory(ListGhost config)
        {
            _config = config;
        }
        
        public GhostGame Create(int id)
        { 
            GhostGame prefabToCreate = _config.GetPrefab(id);
            return UnityEngine.Object.Instantiate(prefabToCreate);
        }
        // public CharacterIA CreateIA(int id, Transform transform)
        // {
        //     CharacterIA prefabToCreate = _configIA.GetPrefab(id);
        //     return UnityEngine.Object.Instantiate(prefabToCreate, transform);
        // }
    }
}