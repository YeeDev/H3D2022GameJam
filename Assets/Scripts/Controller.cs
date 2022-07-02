using UnityEngine;
using NTR.Movement;

namespace NTR.Controllers
{
    [RequireComponent(typeof(Mover))]
    public class Controller : MonoBehaviour
    {
        bool holdH;
        bool holdV;
        bool horizontalPressedLast;
        Vector3 moveDirection;

        Mover mover;

        private void Awake()
        {
            mover = GetComponent<Mover>();
        }

        private void Update()
        {
            CalculateInputDirection();
            CalculateAnimationParameters();
        }

        private void FixedUpdate()
        {
            MoveCharacter();
        }

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

        private void MoveCharacter()
        {
            mover.MoveInDirection(moveDirection, horizontalPressedLast);
        }
    }
}