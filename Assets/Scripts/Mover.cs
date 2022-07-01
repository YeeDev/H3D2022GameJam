using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField][Range(-10, 10)] float moveSpeed = 0;

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
        }

        private void FixedUpdate()
        {
            Vector3 moveVelocity = new Vector3(moveDirection.x, 0, moveDirection.y).normalized * moveSpeed;
            rb.MovePosition(transform.position + moveVelocity);
        }
    }
}