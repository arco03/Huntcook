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
                GhostGame enemy = _enemy.Create(i);
                Ingredient food = _food.Create(i);
                
                food.transform.position = new Vector3(11.6999998f +i * 2,1.04999995f ,-3.86999989f);
                enemy.transform.position = new Vector3(-1.48000002f + i, 1f, 3.6500001f);
            }



            
         
            
        }
    }
}
