using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour
{

    private int jumped = 0;
    private int jumpCount = 2;

    private Rigidbody2D rgbd2d;
    private Animator animator;

    public void SetJumpCount(int newJumpCount)
    {
        jumpCount = newJumpCount;
    }

    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump())
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        jumped++;
        rgbd2d.AddForce(Vector2.up * 200);

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            resetJump();
            animator.SetInteger(AnimaParmName.MotionState, (int)MotionState.Idle);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            animator.SetInteger(AnimaParmName.MotionState, (int)MotionState.Jump);
        }
    }

    private bool canJump()
    {
        return jumped < jumpCount;
    }

    private void resetJump()
    {
        jumped = 0;
    }

}
