using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Mixer : MonoBehaviour, IInteraction
    {
        public void Interact(Ingredients ingredient)
        {
            Debug.Log($"You are Mixing ! {ingredient}");
        }
    }
}