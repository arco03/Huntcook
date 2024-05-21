using Interactable;
using Scriptable;

namespace Installer
{
    public class FactoryRecipe
    {
        private readonly RecipeData _config;
        
        public FactoryRecipe(RecipeData config)
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