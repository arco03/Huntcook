using UnityEngine;

namespace _Scripts.Dish
{
    public class DishManager : MonoBehaviour
    {
        public delegate void DishCompletedHandler(DishData dishData);
        public static event DishCompletedHandler OnDishReady;
        
        public static void DishReady(DishData dishData) => OnDishReady?.Invoke(dishData);
        private DishSpawner _dishSpawner;
        
        [SerializeField] private DishConfiguration dishConfiguration;
        private void Awake()
        {
            OnDishReady += HandleDishReady;
            DishFactory dishFactory = new DishFactory(dishConfiguration);
            _dishSpawner = new DishSpawner(dishFactory);
        }

        public void Initialize(DishData dish, Transform positionPlate)
        {
            _dishSpawner.Spawn(dish, positionPlate);
        }

        private void HandleDishReady(DishData dishData)
        {
            Debug.Log($"¡El plato {dishData.recipeName} está listo!");
        }
    }
}