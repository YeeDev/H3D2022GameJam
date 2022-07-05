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
                    if (checkIngredient != null)
                    {
                        currentIngredient.CopyIngredient(checkIngredient);
                        ingredientHolder.sprite = currentIngredient.sprite;
                        Debug.Log($"My current ingredient is {currentIngredient.ingredientName}");
                    }
                }
                else
                {
                    interactable.GetComponent<IInteractable>().Interact();
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