namespace _Scripts.Dish
{
    public class DishFactory
    {
        private readonly DishConfiguration _config;

        public DishFactory(DishConfiguration config)
        {
            _config = config;
        }

        public Dish Create(DishData data)
        { 
            Dish prefabToCreate = _config.GetPrefab(data);
            return UnityEngine.Object.Instantiate(prefabToCreate);
        }
    }
}