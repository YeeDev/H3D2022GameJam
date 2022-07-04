using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] IngredientsTypes ingredient;

        Sprite ingredientSprite;

        public Sprite GetSprite { get => ingredientSprite; }
        public IngredientsTypes GetIngredient { get => ingredient; }

        private void Awake() { ingredientSprite = GetComponent<SpriteRenderer>().sprite; }
    }
}