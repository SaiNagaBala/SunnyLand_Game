using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    Rigidbody2D rb;
    Vector2 movement;
    Animator animator;
    public bool isgrounded = true;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {

    }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        movement.y = Input.GetAxis("Vertical");
        animator.SetFloat("isRunning", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * playerSpeed, rb.velocity.y);
    }

    private void PlayerJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetBool("isJump", true);
        isgrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isgrounded = true;
        if (collision.gameObject.tag == "Platform")
        {
            animator.SetBool("isJump", false);
        }

    }
   

}