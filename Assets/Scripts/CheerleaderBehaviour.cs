using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerleaderBehaviour : MonoBehaviour {
    Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {

    }

    public void Cheer() {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Cheer") && !animator.GetCurrentAnimatorStateInfo(0).IsName("StandingBot")) {
            animator.Play("Cheer");
        }
    }
}
