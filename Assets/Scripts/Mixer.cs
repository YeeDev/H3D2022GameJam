using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTR.Ingredients;

namespace NTR.Interactions
{
    public class Mixer : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("You are using the mixer!");
        }

        public IngredientData GetIngredient()
        {
            return null;
        }
    }
}