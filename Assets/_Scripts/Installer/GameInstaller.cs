using System.Collections;
using System.Collections.Generic;
using _Scripts.Dish;
using _Scripts.Ghost;
using _Scripts.Ingredient;
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
        [SerializeField] private GhostData[] ghostData;
        [SerializeField] private Transform ghost;
        
        [Header("Spawner Configurations")]
        [SerializeField] private float repeatingTime;
        
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


        public void Awake()
        {
            GhostFactory ghostFactory = new GhostFactory(ghostConfiguration);
            _ghostSpawner = new GhostSpawner(ghostVector1, ghostVector2, ghostFactory);
            IngredientFactory ingredientFactory = new IngredientFactory(ingredientConfiguration);
            _ingredientSpawner = new IngredientSpawner(dishData.ingredientsList, ingredientPoints, ingredientFactory);
        }

        private void Start()
        {
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i],ingredientPoints[i].transform.position );
            }
            _instance = this;
            _ingredientSpawner.Initialize();
            StartCoroutine(GhostTime());
            
            InvokeRepeating("Spawn", repeatingTime, repeatingTime);
        }

        private void Spawn()
        {
            _ingredientSpawner.Spawn();
        }

        IEnumerator GhostTime()
        {
            for (int i = 0; i < 3; i++)
            {
               
                yield return new WaitForSeconds(5f);
                _ghostSpawner.Spawn(ghostData[i],ghost);
            }
            
        }

    }
}