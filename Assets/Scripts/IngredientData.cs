using UnityEngine;

namespace NTR.Ingredients
{
    [System.Serializable]
    public class IngredientData
    {
        public IngredientType name;
        public Sprite sprite;

        int timesMixed;
        public int TimesMixed { get => timesMixed; }

        public void Mix() { Mathf.Clamp(timesMixed++, 0, 10); }

        public void CopyIngredient(IngredientData ingredientToCopy)
        {
            name = ingredientToCopy.name;
            timesMixed = ingredientToCopy.timesMixed;
            sprite = ingredientToCopy.sprite;
        }

        public void ResetIngredient()
        {
            name = IngredientType.NONE;
            timesMixed = 0;
            sprite = null;
        }
    }
}