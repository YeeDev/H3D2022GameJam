using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTR.Ingredients;

namespace NTR.Interactions
{
    public class Mixer : MonoBehaviour, IInteractable
    {
        [SerializeField] IngredientData doughData = null; 

        IngredientData holdIngredient = new IngredientData();

        public bool IsIngredient() { return false; }

        public void Interact(IngredientData ingredientData)
        {
            if (ingredientData.name != IngredientType.NONE)
            {
                holdIngredient.CopyIngredient(ingredientData);
                Debug.Log($"Added {holdIngredient.name}!");
            }
            else if (holdIngredient.name != IngredientType.NONE)
            {
                if (holdIngredient.name == IngredientType.Flour)
                {
                    Debug.Log($"You created dough!");
                    holdIngredient = doughData;
                    return;
                }

                holdIngredient.Mix();
                Debug.Log($"Mixing the {holdIngredient.name}!");
            }
            else
            {
                Debug.Log($"Using the mixer for no reason whatsoever!");
            }
        }

        public IngredientData GetIngredient()
        {
            IngredientData dataToReturn = new IngredientData();
            dataToReturn.CopyIngredient(holdIngredient);
            holdIngredient.ResetIngredient();
            return dataToReturn;
        }
    }
}