using System.Collections;
using System.Collections.Generic;
using Installer;
using Interactable;
using Scriptable;
using Spawner;
using UnityEngine;

namespace _Scripts.Installer
{
    [RequireComponent(typeof(Transform))]
    public class GameInstaller : MonoBehaviour
    {
        [Header("Factories configurations")]
        [SerializeField] private GhostConfiguration ghostConfiguration;
        [SerializeField] private IngredientConfiguration ingredientConfiguration;
        [SerializeField] private DishData dishData;
        [SerializeField] private GhostData ghostData;

        [Header("Spawner Configurations")]
        [SerializeField] private float repeatingTime;
        
        [Header("Spawner Positions")]
        [SerializeField] private Transform ghostVector1;
        [SerializeField] private Transform ghostVector2;
        [SerializeField] private List<IngredientPoint> ingredientPoints;
        
        private GhostSpawner _ghostSpawner;
        private IngredientSpawner _ingredientSpawner;

        public void Awake()
        {
            GhostFactory ghostFactory = new GhostFactory(ghostConfiguration);
            _ghostSpawner = new GhostSpawner(ghostVector1, ghostVector2, ghostFactory);
            IngredientFactory ingredientFactory = new IngredientFactory(ingredientConfiguration);
            _ingredientSpawner = new IngredientSpawner(dishData.ingredientsList, ingredientPoints, ingredientFactory);
        }

        private void Start()
        {
            _ingredientSpawner.Initialize();

            for (int i = 0; i < 3; i++)
            {
                _ghostSpawner.Spawn(ghostData);
            }

            InvokeRepeating("Spawn", repeatingTime, repeatingTime);
        }

        private void Spawn()
        {
            _ingredientSpawner.Spawn();
        }
    }
}