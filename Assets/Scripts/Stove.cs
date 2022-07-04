using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Stove : MonoBehaviour, IInteraction
    {
        public void Interact(IngredientsTypes ingredient)
        {
            Debug.Log($"Cooking {ingredient} in the stove!");
        }
    }
}