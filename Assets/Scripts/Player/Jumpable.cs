using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour
{

    private int jumped = 0;
    private int jumpCount = 2;

    private Rigidbody2D rgbd2d;

    public void SetJumpCount(int newJumpCount)
    {
        jumpCount = newJumpCount;
    }

    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
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
        rgbd2d.AddForce(Vector2.up*200);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            resetJump();
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
