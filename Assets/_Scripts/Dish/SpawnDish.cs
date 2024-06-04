using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.Dish
{
    [Serializable]
    public class SpawnDish:MonoBehaviour
    {
        private Transform _positionDish;
        public Transform Position => _positionDish;
        private Dish _dish;
        public Dish Dish => _dish;
       

        public void Configure(Dish dish, Transform positionDish)
        {
            _dish = Instantiate(dish, positionDish);
            _positionDish = positionDish;
        }
       
        
      
        
    }
}