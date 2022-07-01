using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField][Range(-10, 10)] float moveSpeed = 0;

        bool holdH;
        bool holdV;
        bool horizontalPressedLast;
        Vector2 moveDirection;
        Animator anm;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anm = GetComponent<Animator>();
        }

        private void Update()
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDirection.y = Input.GetAxisRaw("Vertical");

            holdH = Input.GetButton("Horizontal");
            holdV = Input.GetButton("Vertical");

            if (holdH && !holdV || holdV && Input.GetButtonDown("Horizontal")) { horizontalPressedLast = true; }
            if (!holdH && holdV || holdH && Input.GetButtonDown("Vertical")) { horizontalPressedLast = false; }

            if (horizontalPressedLast && holdH)
            {
                anm.SetFloat("XInputAxis", moveDirection.x);
                anm.SetFloat("ZInputAxis", 0);
            }
            else if (!horizontalPressedLast && holdV)
            {
                anm.SetFloat("XInputAxis", 0);
                anm.SetFloat("ZInputAxis", moveDirection.y);
            }
        }

        private void FixedUpdate()
        {
            Vector3 moveVelocity = new Vector3(moveDirection.x, 0, moveDirection.y).normalized * moveSpeed;
            rb.MovePosition(transform.position + moveVelocity);
        }
    }
}