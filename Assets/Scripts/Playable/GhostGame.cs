using System;
using System.Collections.Generic;
using Installer;
using Interactable;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Playable
{
    [Serializable]
    public class GhostGame : MonoBehaviour
    {
        public int id;

        public Transform target;
        
        private void Start()
        {
            List<Ingredient> ingredients = GameInstaller.Ingredients;
            int randomIndex = Random.Range(0, ingredients.Count);
            target = ingredients[randomIndex].transform;
        }


        private void Update()
        {
            Vector3.MoveTowards(transform.position, target.position, 0.5f);
        }
    }
}