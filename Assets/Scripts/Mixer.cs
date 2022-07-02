using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Mixer : MonoBehaviour, IInteraction
    {
        public void Interact()
        {
            Debug.Log("You are Mixing Ingredients!");
        }
    }
}