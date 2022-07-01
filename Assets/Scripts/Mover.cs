using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField][Range(-10, 10)] float moveSpeed = 0;

        bool facingLeft;
        Vector2 moveDirection;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDirection.y = Input.GetAxisRaw("Vertical");

            if (facingLeft && moveDirection.x > 0)
            {
                Flip();
            }
            else if (!facingLeft && moveDirection.x < 0)
            {
                Flip();
            }
        }

        private void FixedUpdate()
        {
            Vector3 moveVelocity = new Vector3(moveDirection.x, 0, moveDirection.y).normalized * moveSpeed;
            rb.MovePosition(transform.position + moveVelocity);
        }

        private void Flip()
        {
            facingLeft = !facingLeft;
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
    }
}