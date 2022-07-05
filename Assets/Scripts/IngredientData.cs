using UnityEngine;

namespace NTR.Ingredients
{
    [System.Serializable]
    public class IngredientData
    {
        public string ingredientName;
        public Sprite sprite;

        int timesMixed;

        public void Mix() { Mathf.Clamp(timesMixed++, 0, 10); }

        public void CopyIngredient(IngredientData ingredientToCopy)
        {
            ingredientName = ingredientToCopy.ingredientName;
            timesMixed = ingredientToCopy.timesMixed;
            sprite = ingredientToCopy.sprite;
        }

        public void ResetIngredient()
        {
            ingredientName = null;
            timesMixed = 0;
            sprite = null;
        }
    }
}