using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Dish;
using _Scripts.Ghost;
using _Scripts.Ingredient;
using UnityEngine;
using UnityEngine.Serialization;


namespace _Scripts.Installer
{
    [RequireComponent(typeof(Transform))]
    public class GameInstaller : MonoBehaviour
    {
        [Header("Factories configurations")]
        [SerializeField] private GhostConfiguration ghostConfiguration;
        [SerializeField] private IngredientConfiguration ingredientConfiguration;
        [SerializeField] private DishData[] dishData;
        [SerializeField] public GhostData[] ghostData;
        [SerializeField] private Transform ghost;
        
        [Header("Spawner Configurations")]
        [SerializeField] private float repeatingTime;

        [Header("Configuración del plato")]
        [SerializeField] SpawnDish _spawnDish;

        [SerializeField] private Transform positionPlate;
        [SerializeField] private Dish.Dish dish;
        
        [Header("Spawner Positions")]
        [SerializeField] private Transform ghostVector1;
        [SerializeField] private Transform ghostVector2;
        public List<IngredientPoint> ingredientPoints;
        private readonly Dictionary<StateIa, UnityEngine.Vector3> _positions = new ();
        public StateIa[] enums;
        private static GameInstaller _instance;
        
        public static GameInstaller Instance => _instance;
        [HideInInspector] public GhostSpawner _ghostSpawner;
        private IngredientSpawner _ingredientSpawner;
        private IngredientSpawner _ingredientSpawner2;
        private IngredientSpawner _ingredientSpawner3;


        public bool dead;
        public int totalGhost;
        public int Level;

        [SerializeField] private float timeGhost;
        public void Awake()
        {
            GhostFactory ghostFactory = new GhostFactory(ghostConfiguration);
            _ghostSpawner = new GhostSpawner(ghostVector1, ghostVector2, ghostFactory);
            IngredientFactory ingredientFactory = new IngredientFactory(ingredientConfiguration);

            if (Level == 1)
            {
               _ingredientSpawner = new IngredientSpawner(dishData[0].ingredientsList, ingredientPoints, ingredientFactory);
   
            }

            if (Level == 2)
            {
                _ingredientSpawner = new IngredientSpawner(dishData[0].ingredientsList, ingredientPoints, ingredientFactory);
                _ingredientSpawner2 = new IngredientSpawner(dishData[1].ingredientsList, ingredientPoints, ingredientFactory);

            }

            if (Level == 3)
            {
                _ingredientSpawner = new IngredientSpawner(dishData[0].ingredientsList, ingredientPoints, ingredientFactory);
                _ingredientSpawner2 = new IngredientSpawner(dishData[1].ingredientsList, ingredientPoints, ingredientFactory);
                _ingredientSpawner3 = new IngredientSpawner(dishData[2].ingredientsList, ingredientPoints, ingredientFactory);

            }
            


        }

        private void Start()
        {
            _spawnDish.Configure(dish, positionPlate);
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i],ingredientPoints[i].transform.position );
            }
            _instance = this;

            if (Level == 1)
            {
               _ingredientSpawner.Initialize();
                
            }

            if (Level == 2)
            {
                _ingredientSpawner.Initialize();
                _ingredientSpawner2.Initialize();

            }

            if (Level==3)
            {
                _ingredientSpawner.Initialize();
                _ingredientSpawner2.Initialize();
                _ingredientSpawner3.Initialize();


            }

            
            StartCoroutine(GhostTime());
            
            InvokeRepeating("Spawn", repeatingTime, repeatingTime);
            
            // InvokeRepeating("SpawnDish", repeatingTime, repeatingTime);
            
        }

     
        private void Spawn()
        {
            if (Level == 1)
            {
              _ingredientSpawner.Spawn();
                
            }

            if (Level == 1)
            { 
              _ingredientSpawner.Spawn();
              _ingredientSpawner2.Spawn();
                
            }

            if (Level == 1)
            { 
                _ingredientSpawner.Spawn();
                _ingredientSpawner2.Spawn();
                _ingredientSpawner3.Spawn();

            }
            

        }
        public IEnumerator GhostTime()
        {
            for (int i = 0; i < totalGhost; i++)
            {
                yield return new WaitForSeconds(timeGhost);
                _ghostSpawner.Spawn(ghostData[i],ghost);
            }
            
        }
        public void RespawnGhost(int index)
        {
            dead = false;
            StartCoroutine(RespawnGhostTime(index));
        }

        private IEnumerator RespawnGhostTime(int index)
        {
            yield return new WaitForSeconds(2f);
            _ghostSpawner.Spawn(ghostData[index], ghost);
        }


    }
}