using UnityEngine;
using NTR.Movement;
using NTR.Interactions;

namespace NTR.Controllers
{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Interactor))]
    public class Controller : MonoBehaviour
    {
        bool holdH;
        bool holdV;
        bool horizontalPressedLast;
        Vector3 moveDirection;

        Mover mover;
        Interactor interactor;

        private void Awake()
        {
            mover = GetComponent<Mover>();
            interactor = GetComponent<Interactor>();
        }

        private void Update()
        {
            CalculateInputDirection();
            CalculateAnimationParameters();
            Interact();
        }

        private void FixedUpdate() { MoveCharacter(); }

        private void CalculateInputDirection()
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDirection.z = Input.GetAxisRaw("Vertical");
        }

        private void CalculateAnimationParameters()
        {
            holdH = Input.GetButton("Horizontal");
            holdV = Input.GetButton("Vertical");

            if (holdH && !holdV || holdV && Input.GetButtonDown("Horizontal")) { horizontalPressedLast = true; }
            if (!holdH && holdV || holdH && Input.GetButtonDown("Vertical")) { horizontalPressedLast = false; }
        }

        private void Interact() { if (Input.GetKeyDown(KeyCode.K)) { interactor.ChecForInteractionType(); } }

        private void MoveCharacter() { mover.MoveInDirection(moveDirection, horizontalPressedLast); }
    }
}