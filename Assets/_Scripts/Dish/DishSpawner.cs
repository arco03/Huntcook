using UnityEngine;

namespace _Scripts.Dish
{
    public class DishSpawner
    {
        private readonly DishFactory _dishFactory;
        private DishData _data;
        private Transform _transform;
        public DishSpawner(DishFactory dishFactory)
        {
            _dishFactory = dishFactory;
        }

        public void Spawn(DishData data, Transform transform)
        {
            _data = data;
            _transform = transform;
            Dish dish = _dishFactory.Create(_data);
            dish.transform.position = _transform.position;
        }

        public void Respawn()
        {
            Spawn(_data,_transform);
        }
       
    }
}