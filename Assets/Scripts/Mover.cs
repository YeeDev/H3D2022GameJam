using UnityEngine;

namespace NTR.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField][Range(-10, 10)] float moveSpeed = 0;

        Animator anm;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anm = GetComponent<Animator>();
        }

        public void MoveInDirection(Vector3 moveDirection, bool horizontalPressedLast)
        {
            Vector3 moveVelocity = moveDirection.normalized * moveSpeed;
            rb.MovePosition(transform.position + moveVelocity);

            PlayWalkingAnimation(moveDirection, horizontalPressedLast);
        }

        //TODO Refactor to animation script?
        public void PlayWalkingAnimation(Vector3 moveDirection, bool horizontalPressedLast)
        {
            if (horizontalPressedLast && Mathf.RoundToInt(moveDirection.x) != 0)
            {
                anm.SetFloat("XInputAxis", moveDirection.x);
                anm.SetFloat("ZInputAxis", 0);
            }
            else if (!horizontalPressedLast && Mathf.RoundToInt(moveDirection.z) != 0)
            {
                anm.SetFloat("XInputAxis", 0);
                anm.SetFloat("ZInputAxis", moveDirection.z);
            }
        }
    }
}