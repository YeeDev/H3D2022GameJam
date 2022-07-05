using NTR.Ingredients;

namespace NTR.Interactions
{
    public interface IInteractable
    {
        public void Interact(IngredientData ingredientData);
        public IngredientData GetIngredient();
        public bool IsIngredient();
    }
}