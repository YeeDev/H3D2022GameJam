using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Mixer : MonoBehaviour, IInteraction
    {
        [SerializeField] GameObject dough = null;
        [SerializeField] Transform ingredientHolder = null;

        Ingredient ingredientCreated;
        List<IngredientsTypes> ingredientsInMixer = new List<IngredientsTypes>();

        public void Interact(IngredientsTypes ingredient)
        {
            if (ingredient != IngredientsTypes.NONE) { ingredientsInMixer.Add(ingredient); }

            if (ingredientsInMixer.Contains(IngredientsTypes.Flour) && ingredient == IngredientsTypes.NONE)
            {
                if (ingredientCreated != null)
                {
                    ingredientCreated.MixMore();
                    return;
                }

                ingredientCreated = Instantiate(dough, ingredientHolder.position, Quaternion.identity).GetComponent<Ingredient>();
            }
        }
    }
}