using UnityEngine;
using NTR.Utensils;

namespace NTR.Interactions
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] Transform rayDirectioneer = null;
        [SerializeField] LayerMask utensilMask = 0;

        Transform utensilToUse;

        public void TryToUseUtensil()
        {
            utensilToUse = SearchForUtensil();
            if (utensilToUse != null)
            {
                utensilToUse.GetComponent<IUtensil>().UseUtensil();
            }
        }

        private Transform SearchForUtensil()
        {
            RaycastHit hit;
            Vector3 direction = rayDirectioneer.position - transform.position;
            Physics.Raycast(transform.position, direction, out hit, 0.75f, utensilMask);

            return hit.transform;
        }
    }
}