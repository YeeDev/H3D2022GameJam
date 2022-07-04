using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] IngredientsTypes ingredient;
        [SerializeField] [Range(0, 10)]int mixedTimes = 0;

        Sprite ingredientSprite;

        public Sprite GetSprite { get => ingredientSprite; }
        public IngredientsTypes GetIngredient { get => ingredient; }

        private void Awake() { ingredientSprite = GetComponent<SpriteRenderer>().sprite; }

        public void MixMore() { mixedTimes++; }
    }
}