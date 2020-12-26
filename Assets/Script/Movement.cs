using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    enum CostumInput
    {
        Jump = KeyCode.Space,
        Slide = KeyCode.S
    }

    [SerializeField] private int speed;
    [SerializeField] private float jumpVelocity = 100f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
    private AnimatorOverrideController animator;
    private float JumpHight;
    private float maxJumpHight = 3;

    void Start()
    {
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        animator = GetComponent<AnimatorOverrideController>();
    }

    void Update()
    {
        CheckMovement();
    }

    private void CheckMovement()
    {
        bool jumpIsPressedWhileOnGround = Input.GetKeyDown(KeyCode.Space) && isOnGround();
        if (jumpIsPressedWhileOnGround)
        {
            Jump();
        }
        else if (isOnGround())
        {
            //run (idle state)
            rigidbody2d.velocity = new Vector2(speed, 0);
        }

        AttenuateJumpAtMaxHight();
    }

    private void Jump()
    {
        JumpHight = transform.position.y;
        rigidbody2d.AddForce(new Vector2(0, jumpVelocity));
    }

    private void AttenuateJumpAtMaxHight()
    {
        if (rigidbody2d.velocity.y < 0 || transform.position.y - JumpHight > maxJumpHight)
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * 4.5f * Time.deltaTime;
        }
    }

    private bool isOnGround()
    {
        //There is probalbly better solution to check ground!
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
        return raycastHit2D.collider != null;
    }
}
