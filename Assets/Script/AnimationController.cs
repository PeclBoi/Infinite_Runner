using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : CollisionMannager
{
    private float timeSlided;
    [SerializeField] private float slideTime = 1f;
    [SerializeField] public Animator animator;
    [SerializeField] private BoxCollider2D idleCollider;
    [SerializeField] private BoxCollider2D slideCollider;

    void Start()
    {
        SetHitboxForRunning();
    }

    void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        JumpHandler();
        SlideHandler();
    }


    private void JumpHandler()
    {
        /* Jump is set false in OnCollisionEnter2d(...)*/
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround())
        {
            animator.SetBool("Jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("Jump", false);
        }
    }

    private void SlideHandler()
    {
        if (Input.GetKeyDown(KeyCode.Y) && isOnGround())
        {
            if (animator.GetBool("Slide") == false)
            {
                timeSlided = 0f;
                animator.SetBool("Slide", true);
            }
            SetHitboxForSlide();
        }

        if (animator.GetBool("Slide") == true)
        {
            timeSlided += Time.deltaTime;
            if (timeSlided > slideTime)
            {
                animator.SetBool("Slide", false);
                SetHitboxForRunning();
            }
        }
    }

    private void SetHitboxForSlide()
    {
        idleCollider.enabled = false;
        slideCollider.enabled = true;
    }

    private void SetHitboxForRunning()
    {
        idleCollider.enabled = true;
        slideCollider.enabled = false;
    } 
}
