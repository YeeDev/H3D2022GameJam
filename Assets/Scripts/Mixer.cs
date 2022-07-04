using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Mixer : MonoBehaviour, IInteraction
    {
        List<IngredientsTypes> ingredientsInMixer = new List<IngredientsTypes>();

        public void Interact(IngredientsTypes ingredient)
        {
            if (ingredient != IngredientsTypes.NONE) { ingredientsInMixer.Add(ingredient); }



        }
    }
}