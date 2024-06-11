using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Dish;
using _Scripts.Ingredient;
using _Scripts.UI.Ingredient;
using UnityEngine;

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
        public int count;
        public int index;
        public int level;


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
            for (int i = 0; i < level; i++)
            {
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
            if (count <= data[index].amount)
            {
                count++;
                uiManager.UpdateDish(data[index], data[index].amount - 1);
                Debug.Log("Plato List");
                StartCoroutine(ChangeLightColorTemporarily());
                StartCoroutine(TimeReset());
            }

            if (count == data[index].amount)
            {
                index++;
                count = 0;
                // ingredientController.Close();
                StartCoroutine(TimeReset());

                if (index >= data.Length)
                {
                    OnDishComplete?.Invoke();
                    return;
                }
                uiManager.UpdateDish(data[index]);
            }
            Debug.Log($"Count {count}");
            Debug.Log($"Index {index}");
            Debug.Log($"Data Index {data[index]}");
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