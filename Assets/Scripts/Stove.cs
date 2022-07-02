using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Stove : MonoBehaviour, IInteraction
    {
        public void Interact(Ingredients ingredient)
        {
            Debug.Log($"You are cooking {ingredient} with a pan!");
        }
    }
}