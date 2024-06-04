using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.Dish
{
    [Serializable]
    public class SpawnDish
    {
        private  Transform _positionDish;
        private  Dish _dish;
       

        public SpawnDish(Dish dish, Transform positionDish)
        {
            _dish = Object.Instantiate(dish, positionDish);
            _positionDish = positionDish;
        }
       
        
      
        
    }
}