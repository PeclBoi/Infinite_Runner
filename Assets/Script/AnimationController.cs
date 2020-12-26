﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    Rigidbody2D rigidbody2d;
    private float timeSlided;
    [SerializeField] private float slideTime = 1f;
    [SerializeField] public Animator animator;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private BoxCollider2D idleCollider;
    [SerializeField] private BoxCollider2D slideCollider;

    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collider) {
        print("Hit");
        if(collider.gameObject.tag == "Ground") {
            animator.SetBool("Jump", false);
        }
    }

    void Start()
    {
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()) {
            animator.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Y) && isOnGround())
        {
            if(animator.GetBool("Slide") == false)
            {           
                timeSlided = 0f;
                animator.SetBool("Slide", true);
            }
            idleCollider.enabled = false;
            slideCollider.enabled = true;
        }

        if (animator.GetBool("Slide") == true)
        {
            timeSlided += Time.deltaTime;
            if(timeSlided > slideTime)
            {
                animator.SetBool("Slide", false);
                idleCollider.enabled = true;
                slideCollider.enabled = false;
            }
        }

       
    }

    private bool isOnGround() {
        // return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerMask);
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
        return raycastHit2D.collider != null;
    }

}
