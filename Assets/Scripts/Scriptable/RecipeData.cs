using System.Collections.Generic;
using Interactable;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(menuName = "Create Recipe", fileName = "Recipe")]
    public class RecipeData : ScriptableObject
    {
        //public int id;
        //public string recipeName;
        public List <Ingredient> recipeList;
        //public Dish dish; //Aun no tengo muy claro como funcionaria esta parte 
    }
}