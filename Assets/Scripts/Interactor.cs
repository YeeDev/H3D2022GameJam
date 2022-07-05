using UnityEngine;
using NTR.Ingredients;

namespace NTR.Interactions
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] Transform rayDirectioneer = null;
        [SerializeField] LayerMask utensilMask = 0;
        [SerializeField] SpriteRenderer ingredientHolder = null;

        Transform interactable;
        IngredientData currentIngredient = new IngredientData();

        public void TryInteraction(bool checkForIngredient)
        {
            interactable = SearchForInteractable();
            if (interactable != null)
            {
                if (checkForIngredient)
                {
                    IngredientData checkIngredient = interactable.GetComponent<IInteractable>().GetIngredient();
                    if (checkIngredient.name != IngredientType.NONE)
                    {
                        currentIngredient.CopyIngredient(checkIngredient);
                        ingredientHolder.sprite = currentIngredient.sprite;
                        Debug.Log($"My current ingredient is {currentIngredient.name}");
                        Debug.Log($"It has been mixed {currentIngredient.TimesMixed} times");
                    }
                }
                else
                {
                    IInteractable interactbaleToUse = interactable.GetComponent<IInteractable>();
                    interactbaleToUse.Interact(currentIngredient);

                    if (!interactbaleToUse.IsIngredient())
                    {
                        currentIngredient.ResetIngredient();
                        ingredientHolder.sprite = null;
                    }
                }
            }
        }

        private Transform SearchForInteractable()
        {
            RaycastHit hit;
            Vector3 direction = rayDirectioneer.position - transform.position;
            Physics.Raycast(transform.position, direction, out hit, 0.75f, utensilMask);

            return hit.transform;
        }
    }
}