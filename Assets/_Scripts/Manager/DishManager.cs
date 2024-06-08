
﻿using System.Collections;
using _Scripts.Dish;

﻿using System;
using System.Collections;
using _Scripts.Installer;
using Unity.VisualScripting;

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
        [HideInInspector]public DishData[] data;
        private Transform _transform;
        public int count = 0;
        public int variable = 1;
        public bool changePlate;
        public int index = 0;
        

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

        public void Initialize(DishData[] dish, Transform positionPlate)

        {
            data = dish;
            _transform = positionPlate;
            
            _dishSpawner.Spawn(data[index], _transform);
        }

        private void HandleDishReady(DishData dataDish)
        {

            dishData = dataDish;
            if (count <= 3)
            {

            if (count <= variable)
            { 
               count++;

               Debug.Log("Plato List");
               StartCoroutine(TimeReset());
            }

            if(count > variable )
            {
                index++;
                count = 0 ;
                StartCoroutine(TimeReset());
                
            }
            
            Debug.Log($"Conteo {count}");
        }

        IEnumerator TimeReset()
        {
            yield return new WaitForSeconds(3f);
            _dishSpawner.Respawn(data[index]);

        }

    }
}