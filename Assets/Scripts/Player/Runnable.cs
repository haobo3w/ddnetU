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

        var motionState = (MotionState)animator.GetInteger(AnimaParmName.MotionState);
        if (moveDir == 0)
        {
            if (motionState == MotionState.Run)
            {
                animator.SetInteger(AnimaParmName.MotionState, (int)MotionState.Idle);
            }
        }
        else
        {
            if (motionState == MotionState.Idle)
            {
                animator.SetInteger(AnimaParmName.MotionState, (int)MotionState.Run);
                animator.SetFloat(AnimaParmName.Speed, rgbd2d.velocity.x);
                animator.SetBool(AnimaParmName.RunLeft, moveDir < 0);
            }
            
            rgbd2d.AddForce((moveDir < 0 ? Vector2.left : Vector2.right) * 10);
        }
    }
}
