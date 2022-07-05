using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTR.Ingredients;

namespace NTR.Interactions
{
    public class Ingredient : MonoBehaviour, IInteractable
    {
        [SerializeField] IngredientData ingredientData = null;

        public bool IsIngredient() { return true; }
        public IngredientData GetIngredient() { return ingredientData; }

        public void Interact(IngredientData ingredientData) { }
    }
}