using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runnable : MonoBehaviour
{

    private Rigidbody2D rgbd2d;
    private Animator animator;

    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        float moveDir = Input.GetAxisRaw("Horizontal");
       
        if (moveDir == 0)
        {
            animator.SetInteger("motionState", (int)MotionState.Idle);
        }
        else
        {
            animator.SetInteger("motionState", (int)MotionState.Run);
            animator.SetFloat("speed", rgbd2d.velocity.x);
            animator.SetBool("runLeft", moveDir < 0);
            rgbd2d.AddForce((moveDir < 0 ? Vector2.left : Vector2.right) * 10);
        }
    }
}
