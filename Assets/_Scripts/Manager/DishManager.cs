using System.Collections;
using _Scripts.Dish;
using UnityEngine;

namespace _Scripts.Manager
{
    public class DishManager : MonoBehaviour
    {
        public delegate void DishCompletedHandler(DishData dishData);
        public static event DishCompletedHandler OnDishReady;
        public UIManager uiManager;
        
        public static void DishReady(DishData dishData) => OnDishReady?.Invoke(dishData);
        private DishSpawner _dishSpawner;
        
        [SerializeField] private DishConfiguration dishConfiguration;
        [SerializeField] private DishData dishData;
        public int count;
        private void Awake()
        {

              OnDishReady += HandleDishReady;
    
            DishFactory dishFactory = new DishFactory(dishConfiguration);
            _dishSpawner = new DishSpawner(dishFactory);
        }

        private void Start()
        {
            uiManager.UpdateDish(dishData.image, dishData.amount);
        }

        public void Initialize(DishData dish, Transform positionPlate)
        {
            _dishSpawner.Spawn(dish, positionPlate);
        }

        private void HandleDishReady(DishData dataDish)
        {
            dishData = dataDish;
            if (count <= 3)
            {
               Debug.Log("Plato List");
               StartCoroutine(TimeReset(dishData));
              
            }
            count++;
        }

        IEnumerator TimeReset(DishData _dishData)
        {
            yield return new WaitForSeconds(3f);
            _dishSpawner.Respawn(_dishData);

        }
    }
}