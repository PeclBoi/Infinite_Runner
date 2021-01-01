﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CollisionMannager
{
    enum CostumInput
    {
        Jump = KeyCode.Space,
        Slide = KeyCode.S
    }

    [SerializeField] private int speed;
    [SerializeField] private float jumpVelocity = 100f;
    
    private Rigidbody2D rigidbody2d;
    private float JumpHight;
    private float maxJumpHight = 3;

    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
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

    
}
