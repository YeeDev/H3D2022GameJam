using UnityEngine;

namespace NTR.Interactions
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] Transform checker = null;
        [SerializeField] [Range(0.01f, 5f)] float checkerRadius = 1;
        [SerializeField] LayerMask interactablesMask = 0;
        [SerializeField] SpriteRenderer carriedIngredient = null;

        Ingredients ingredientCarrying = Ingredients.NONE;

        public void ChecForInteractionType()
        {
            RaycastHit hit;
            Physics.SphereCast(transform.position, checkerRadius, checker.position, out hit, 1f, interactablesMask);

            if (hit.transform != null)
            {
                IInteraction interaction = hit.transform.GetComponent<IInteraction>();

                if (interaction == null) { IngredientInteraction(hit.transform); }
                else { CookInteraction(interaction); }
            }
        }

        private void IngredientInteraction(Transform hitTransform)
        {
            Ingredient ingredient = hitTransform.GetComponent<Ingredient>();
            SetIngredient(ingredient);
        }

        //TODO set in animation script?
        private void SetIngredient(Ingredient ingredient)
        {
            ingredientCarrying = ingredient != null ? ingredient.GetIngredient : Ingredients.NONE;
            carriedIngredient.sprite = ingredient != null ?  ingredient.GetSprite : null;
        }

        private void CookInteraction(IInteraction objectToInteractWith)
        {
            objectToInteractWith.Interact(ingredientCarrying);
            SetIngredient(null);
        }

        private void OnDrawGizmos()
        {
            if (checker == null) { return; }

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(checker.position, checkerRadius);
        }
    }
}