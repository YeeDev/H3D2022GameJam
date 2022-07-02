using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Stove : MonoBehaviour, IInteraction
    {
        public void Interact()
        {
            Debug.Log("You are cooking with a pan!");
        }
    }
}