using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour
{

    private int jumped = 0;
    public int JumpCount = 2;

    public float DefaultSpeed = 3;

    private Rigidbody2D rgbd2d;
    private Animator animator;

    public void SetJumpCount(int newJumpCount)
    {
        JumpCount = newJumpCount;
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
        rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, jumped > 0 ? DefaultSpeed / 2 : DefaultSpeed);

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            resetJump();
            animator.SetInteger(AnimaParmName.MotionState, (int)MotionState.Idle);
            rgbd2d.velocity = new Vector2(0, rgbd2d.velocity.y);
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
        return jumped < JumpCount;
    }

    private void resetJump()
    {
        jumped = 0;
    }

}
