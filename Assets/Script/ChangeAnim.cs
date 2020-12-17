using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : MonoBehaviour {
    private Animator animator;
    [SerializeField] private AnimatorOverrideController clip;
    public int i;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space))
            SetAnimator(clip);
    }

    public void SetAnimator(AnimatorOverrideController overrideController) {
        animator.runtimeAnimatorController = overrideController;
    }
}
