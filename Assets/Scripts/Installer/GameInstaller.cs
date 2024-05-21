using System;
using Interactable;
using Playable;
using Scriptable;
using UnityEngine;


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
                GhostGame enemy = _enemy.Create(0);
                Ingredient food = _food.Create(i);
                
                food.transform.position = new Vector3(6.57000017f,1.71200001f ,0f+i * 2);
                enemy.transform.position = new Vector3(-1.48000002f + i, 1f, 3.6500001f + i);
                
            }
            
            



            
         
            
        }
    }
}
