using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controles : MonoBehaviour
{
    public float xmove = 4;

    public float ymove = 3;

    public SpriteRenderer spriteRenderer;

    public bool BetterJump = false;

    public float fallMultiplier = 0.5f;

    public float InitfallMultiplier = 0.5f;

    public float LowJumpMultiplier = 1f;

    Rigidbody2D rb2d;

    public Animator animator;

    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
       
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(xmove, rb2d.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("run" , true);
        }
       
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-xmove, rb2d.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("run",true);
        }
        
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("run", false);
        }

        if (CheckGround.isGrounded && Input.GetKey("space"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, ymove);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
            animator.SetBool("run", false);
        }
        
        if (BetterJump)
        {
            if (rb2d.velocity.y<0)
            {
                rb2d.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier)*Time.deltaTime;
            }

            if (rb2d.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2d.velocity += Vector2.up * Physics.gravity.y * (LowJumpMultiplier) *Time.deltaTime;
            }
        }
        if (Input.GetKey("s") && rb2d.velocity.y != 0)
        {
            fallMultiplier = 10;
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (CheckGround.isGrounded)
        {
            fallMultiplier = InitfallMultiplier;
        }
     
    }
}
