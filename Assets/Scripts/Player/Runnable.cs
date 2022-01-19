using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runnable : MonoBehaviour
{

    private Rigidbody2D rgbd2d;
    private Animator animator;

    public float DefaultSpeed = 3;

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
            Stop(motionState);
        }
        else
        {
            Run(motionState, moveDir < 0);
        }
    }


    private void Run(MotionState motionState, bool runLeft)
    {
        float speed = DefaultSpeed;
        if (motionState == MotionState.Idle)
        {
            animator.SetInteger(AnimaParmName.MotionState, (int)MotionState.Run);
            animator.SetFloat(AnimaParmName.Speed, rgbd2d.velocity.x);
            animator.SetBool(AnimaParmName.RunLeft, runLeft);
        }
        else if (motionState == MotionState.Jump)
        {
            speed /= 1.5f;
        }
        rgbd2d.velocity = new Vector2(runLeft ? -speed : DefaultSpeed, rgbd2d.velocity.y);
    }

    private void Stop(MotionState motionState)
    {
        if (motionState == MotionState.Run)
        {
            animator.SetInteger(AnimaParmName.MotionState, (int)MotionState.Idle);
            rgbd2d.velocity = new Vector2(0, rgbd2d.velocity.y);
        }
    }

}
