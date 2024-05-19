using Interactable;
using Scriptable;

namespace Installer
{
    public class FactoryFood
    {
        private readonly IngredientsData _config;
        
        public FactoryFood(IngredientsData config)
        {
            _config = config;
        }
        
        public Ingredient Create(int id)
        { 
            Ingredient prefabToCreate = _config.GetPrefab(id);
            return UnityEngine.Object.Instantiate(prefabToCreate);
        }
    }
}