using NTR.Ingredients;

namespace NTR.Interactions
{
    public interface IInteractable
    {
        public void Interact();
        public IngredientData GetIngredient();
    }
}