using UnityEngine;

namespace _Scripts.Dish
{
    public class DishSpawner
    {
        private readonly DishFactory _dishFactory;

        public DishSpawner(DishFactory dishFactory)
        {
            _dishFactory = dishFactory;
        }

        public void Spawn(DishData data, Transform transform)
        {
            Dish dish = _dishFactory.Create(data);
            dish.transform.position = transform.position;
        }
       
    }
}