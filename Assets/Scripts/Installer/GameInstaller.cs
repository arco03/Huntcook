using System;
using Interactable;
using Playable;
using Scriptable;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Installer
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private ListGhost config;
        [SerializeField] private IngredientsData configFood;
        
        private ConfigureFactory _enemy;
        private FactoryFood _food;
        
        public int id;

        public void Awake()
        {
            _enemy = new ConfigureFactory(config);
            _food = new FactoryFood(configFood);

        }

        public void Start()
        {
            for(int i = 0; i < 3; i++)
            { 
                float posX = Random.Range(-5, 5);
                float posZ = Random.Range(-3, 8);
                
                GhostGame enemy = _enemy.Create(0);
                Ingredient food = _food.Create(i);
                
                food.transform.position = new Vector3(6.57000017f,1.71200001f ,0f+i * 2);
                enemy.transform.position = new Vector3(posX , 1f, posZ );

                // enemy.AddIngredient(food);

            }
            
            



            
         
            
        }
    }
}
