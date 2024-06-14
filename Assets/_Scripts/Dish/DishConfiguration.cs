using System.Collections.Generic;
using _Scripts.Ghost;
using UnityEngine;

namespace _Scripts.Dish
{
    [CreateAssetMenu(fileName = "DishConfiguration", menuName = "DishConfiguration", order = 0)]
    public class DishConfiguration : ScriptableObject
    {
        public List<Dish> dishes;
        
        public Dish GetPrefab(DishData id)
        {
            return dishes.Find(dish => dish.dishData == id);
        }
    }
}