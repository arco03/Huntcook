using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Audio;
using _Scripts.Dish;
using _Scripts.Ingredient;
using _Scripts.UI.Ingredient;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Manager
{
    public class DishManager : MonoBehaviour
    {
        public delegate void DishCompletedHandler(DishData dishData);

        public static event DishCompletedHandler OnDishReady;
        public static event Action OnDishComplete;
        public UIManager uiManager;

        public static void DishReady(DishData dishData) => OnDishReady?.Invoke(dishData);
        private DishSpawner _dishSpawner;

        [Header("Spawner Configurations")] [SerializeField]
        private float repeatingTime;

        [SerializeField] private DishConfiguration dishConfiguration;
        [HideInInspector] public DishData[] data;

        [SerializeField] private IngredientConfiguration ingredientConfiguration;
        private IngredientSpawner _ingredientSpawner;
        public List<IngredientPoint> ingredientPoints;
        [SerializeField] private IngredientController ingredientController;

        [SerializeField] private Light lightPoint;
        [SerializeField] private Color readyColor;

        private Transform _transform;
        public int count = 0;
        public int index;
        public int level;
        public string soundName;

        private void Awake()
        {
            
            OnDishReady += HandleDishReady;
            DishFactory dishFactory = new DishFactory(dishConfiguration);
            _dishSpawner = new DishSpawner(dishFactory);

            IngredientFactory ingredientFactory = new IngredientFactory(ingredientConfiguration);
            _ingredientSpawner = new IngredientSpawner(ingredientPoints, ingredientFactory);
        }

        private void Start()
        {
            TypeLevel(level);
            InvokeRepeating(nameof(Spawn), repeatingTime, repeatingTime);
            uiManager.UpdateDish(data[index]);
        }



        private void TypeLevel(int level)
        {
            int minAmount = 1; // Mínimo valor posible para el amount
            int maxAmount = 6; // Máximo valor posible para el amount
            int initialAmount = Random.Range(minAmount, maxAmount + 1); 
            
            for (int i = 0; i < level && i < data.Length; i++)
            {
                data[i].amount = initialAmount;
                _ingredientSpawner.Initialize(data[i].ingredientsList);
                
            }
        }
        
        private void Spawn()
        {
            _ingredientSpawner.Spawn();
        }

        public void Initialize(DishData[] dish, Transform positionPlate)
        {
            data = dish;
            _transform = positionPlate;

            _dishSpawner.Spawn(data[index], _transform);
        }

        private void HandleDishReady(DishData dataDish)
        {
            if (index >= data.Length)
                return;
            while (count <= data[index].amount)
            {
                data[index].amount--;
                uiManager.UpdateDish(data[index]);
                 
                
                Debug.Log($"Plato List {data[index].amount}");
                AudioManager.instance.PlaySfx(soundName);
                StartCoroutine(ChangeLightColorTemporarily());
                StartCoroutine(TimeReset());
                
                Debug.Log($"Count {count}");

                // Esperar un frame antes de continuar con el bucle
                if (count < data[index].amount)
                {
                    return;
                }
                
                count++;
                Debug.Log($"Index {index}");
                Debug.Log($"Data Index {data[index]}");
            }

            if (count > data[index].amount)
            {
                index++;
                count = 0;
               
                if (index < data.Length)
                    uiManager.UpdateDish(data[index]);
                if (index >= data.Length)
                    OnDishComplete?.Invoke();

            }
            // uiManager.UpdateDish(data[index])

        }

        private IEnumerator TimeReset()
        {
            yield return new WaitForSeconds(3f);
            _dishSpawner.Respawn(data[index]);
        }

        private IEnumerator ChangeLightColorTemporarily()
        {
            if (lightPoint)
            {
                Color originalColor = lightPoint.color;
                lightPoint.color = readyColor;
                yield return new WaitForSeconds(3f);
                lightPoint.color = originalColor;
            }
        }
    }
}