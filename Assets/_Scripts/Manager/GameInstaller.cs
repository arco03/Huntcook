using System.Collections;
using System.Collections.Generic;
using _Scripts.Dish;
using _Scripts.Ghost;
using _Scripts.Ingredient;
using UnityEngine;

namespace _Scripts.Manager
{
    [RequireComponent(typeof(Transform))]
    public class GameInstaller : MonoBehaviour
    {
        [Header("Factories configurations")]
        [SerializeField] private GhostConfiguration ghostConfiguration;
        [SerializeField] private IngredientConfiguration ingredientConfiguration;
        [SerializeField] public GhostData[] ghostData;
        [SerializeField] private Transform ghost;
        public DishData[] dish;
        
        [Header("Spawner Configurations")]
        [SerializeField] private float repeatingTime;

        [Header("Dish Configuration")]

        [SerializeField] private DishManager dishManager;

        [SerializeField] private Transform dishPosition;
        
        [Header("Spawner Positions")]
        [SerializeField] private Transform ghostVector1;
        [SerializeField] private Transform ghostVector2;
        public List<IngredientPoint> ingredientPoints;
        private readonly Dictionary<StateIa, Vector3> _positions = new ();
        public StateIa[] enums;
        private static GameInstaller _instance;
        
        public static GameInstaller Instance => _instance;
        private GhostSpawner _ghostSpawner;
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
            _ingredientSpawner = new IngredientSpawner(ingredientPoints, ingredientFactory);
        }

        private void Start()
        {
            
          dishManager.Initialize(dish,dishPosition);
            
  

            TypeLevel(Level);
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i],ingredientPoints[i].transform.position );
            }
            _instance = this;
            
            StartCoroutine(GhostTime());
            
            InvokeRepeating("Spawn", repeatingTime, repeatingTime);
          
         
        }


        private void TypeLevel(int level)
        {
            for (int i = 0; i<level;i++)
            {
                _ingredientSpawner.Initialize(dish[i].ingredientsList);
                
            }
        }

        private void Spawn()
        {
            _ingredientSpawner.Spawn();


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