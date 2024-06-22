﻿using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Audio;
using _Scripts.Dish;
using _Scripts.Ghost;
using _Scripts.Ingredient;
using UnityEngine;
using UnityEngine.Serialization;

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

        [Header("Dish Configuration")]

        [SerializeField] public DishManager dishManager;

        [SerializeField] private Transform dishPosition;
        
        [Header("Spawner Positions")]
        [SerializeField] private Transform ghostVector1;
        [SerializeField] private Transform ghostVector2;
        
        private readonly Dictionary<StateIa, Vector3> _positions = new ();
        public StateIa[] enums;
        private static GameInstaller _instance;
        
        public static GameInstaller Instance => _instance;
        private GhostSpawner _ghostSpawner;
        private IngredientSpawner _ingredientSpawner;
        
        public bool dead;
        public int totalGhost;

        [SerializeField] private float timeGhost;
        [SerializeField] private string musicLevel;
        [SerializeField] private AudioManager audioManager;

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            GhostFactory ghostFactory = new GhostFactory(ghostConfiguration);
            _ghostSpawner = new GhostSpawner(ghostVector1, ghostVector2, ghostFactory);
            
            dishManager.Initialize(dish,dishPosition);

            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i],dishManager.ingredientPoints[i].transform.position );
            }
            

            StartCoroutine(GhostTime());
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.PlayMusic(musicLevel);
        }

        public IEnumerator GhostTime() {
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