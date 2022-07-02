using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Oven : MonoBehaviour, IInteraction
    {
        public void Interact(Ingredients ingredient)
        {
            Debug.Log($"Cooking {ingredient} in the oven!");
        }
    }
}