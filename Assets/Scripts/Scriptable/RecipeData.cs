using System.Collections.Generic;
using Interactable;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(menuName = "Create Recipe", fileName = "Recipe")]
    public class RecipeData : ScriptableObject
    {
        [HideInInspector] int id;
        //public string recipeName;
        public List <Ingredient> recipeList;
        //public Dish dish; //Aun no tengo muy claro como funcionaria esta parte 
        public Ingredient GetPrefab(int id)
        {
            this.id = id;
            return recipeList.Find(recipe => recipe.id == id);

        }
    }
}