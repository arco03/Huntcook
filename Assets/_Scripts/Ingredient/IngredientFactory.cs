namespace _Scripts.Ingredient
{
    public class IngredientFactory
    {
        private readonly IngredientConfiguration _configuration;

        public IngredientFactory(IngredientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Ingredient Create(IngredientData data)
        {
            Ingredient ingredient = _configuration.GetPrefab(data);
            return UnityEngine.Object.Instantiate(ingredient);
        }
    }
}