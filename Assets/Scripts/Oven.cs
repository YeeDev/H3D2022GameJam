using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Oven : MonoBehaviour, IInteraction
    {
        public void Interact()
        {
            Debug.Log("Cooking something in the oven!");
        }
    }
}