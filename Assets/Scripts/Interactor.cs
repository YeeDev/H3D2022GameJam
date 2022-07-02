using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Interactions
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] Transform checker = null;
        [SerializeField] [Range(0.01f, 5f)] float checkerRadius = 1;
        [SerializeField] LayerMask interactablesMask = 0;
        [SerializeField] SpriteRenderer carriedIngredient = null;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                RaycastHit hit;
                Physics.SphereCast(transform.position, checkerRadius, checker.position, out hit, 1f, interactablesMask);

                if (hit.transform != null)
                {
                    IInteraction interaction = hit.transform.GetComponent<IInteraction>();

                    if (interaction == null)
                    {
                        carriedIngredient.sprite = hit.transform.GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        interaction.Interact();
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (checker == null) { return; }

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(checker.position, checkerRadius);
        }
    }
}