using UnityEngine;

namespace NTR.Interactions
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] Transform checker = null;
        [SerializeField] [Range(0.01f, 5f)] float checkerRadius = 1;
        [SerializeField] LayerMask ingredientMask = 0;
        [SerializeField] LayerMask utensilMask = 0;
        [SerializeField] SpriteRenderer carriedIngredient = null;

        IngredientsTypes ingredientCarrying = IngredientsTypes.NONE;

        public void GrabIngredient()
        {
            Transform ingredientToGrab = ReturnObjectToInteractWith(ingredientMask);

            if (ingredientToGrab != null) { SetIngredient(ingredientToGrab.GetComponent<Ingredient>()); }
        }

        public void UseUtensil()
        {
            Transform utensil = ReturnObjectToInteractWith(utensilMask);

            if (utensil != null)
            {
                utensil.GetComponent<IInteraction>().Interact(ingredientCarrying);
                SetIngredient(null);
            }
        }

        public Transform ReturnObjectToInteractWith(LayerMask maskToSearch)
        {
            RaycastHit hit;
            Physics.SphereCast(transform.position, checkerRadius, checker.position, out hit, 1f, maskToSearch);

            return hit.transform;
        }

        //TODO set in animation script?
        private void SetIngredient(Ingredient ingredient)
        {
            ingredientCarrying = ingredient != null ? ingredient.GetIngredient : IngredientsTypes.NONE;
            carriedIngredient.sprite = ingredient != null ? ingredient.GetSprite : null;
        }

        private void OnDrawGizmos()
        {
            if (checker == null) { return; }

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(checker.position, checkerRadius);
        }
    }
}