using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    Rigidbody2D rigidbody2d;
    [SerializeField] public Animator animator;
    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collider) {
        print("Hi");
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
        if (animator.GetBool("Slide") == true)
        {
            animator.SetBool("Slide", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()) {
            animator.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Y) && isOnGround())
        {
            if(animator.GetBool("Slide") == false)
            {
                print("slide");
                animator.SetBool("Slide", true);
            } 
        }

       
    }

    private bool isOnGround() {
        // return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerMask);
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
        return raycastHit2D.collider != null;
    }

}
