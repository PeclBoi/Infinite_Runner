using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    // [SerializeField] private Sprite[] sprites;
    [SerializeField] private int speed;
    [SerializeField] private float jumpVelocity = 100f;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask layerMask;
    private AnimatorOverrideController animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    float x;

    void Start() {
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        animator = GetComponent<AnimatorOverrideController>();
    }

    void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.S)) {
            //Slide
            print("slide");
        }
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()) {
            x = transform.position.y;
            rigidbody2d.AddForce(new Vector2(0, jumpVelocity));
        }
        else if (isOnGround()) {
            rigidbody2d.velocity = new Vector2(speed, 0);
        }

        if (rigidbody2d.velocity.y < 0 || transform.position.y - x > 3) {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * 4.5f * Time.deltaTime;
        }
    }

    private bool isOnGround() {

       // return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerMask);
         RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
         return raycastHit2D.collider != null;
    }
}
