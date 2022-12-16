using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private AudioSource jumpSourceEffect;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform groundCheck;

    [Header("Coyote time")]
    [SerializeField] private float coyoteTime;
    [SerializeField] private float coyoteCounter;

    private float dirX = 0f;
    [SerializeField] private bool isGrounded;
    private bool isWallTouch;
    private bool isSliding;
    private bool wallJumping;
    private bool doubleJump;
    private bool doubleJump2;
    [SerializeField] private float wallJumpDuration;
    [SerializeField] private Vector2 wallJumpForce;
    [SerializeField] private float wallSlideSpeed;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling, walljumping, doubleJump}

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(.9f, .15f), 0, jumpableGround);
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(.2f, 1.4f), 0, jumpableGround);

        if (isGrounded)
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpSourceEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = true;
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            if (!doubleJump)
            {
                jumpSourceEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = false;
                doubleJump2 = true;
            }
            else if (coyoteCounter > 0)
            {
                jumpSourceEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;
            }
            coyoteCounter = 0;
        }

        if (isWallTouch && !isGrounded && dirX != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        if (Input.GetButtonDown("Jump") && isSliding)
        {
            jumpSourceEffect.Play();
            wallJumping = true;
            Invoke("StopWallJump", wallJumpDuration);
        }

        flip();
        UpdateAnimationState();
    }
    private void FixedUpdate()
    {
        if(isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        if (wallJumping)
        {
            rb.velocity = new Vector2(-dirX * wallJumpForce.x, wallJumpForce.y);
        }
        else
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            //sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            //sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (wallJumping)
        {
            state = MovementState.walljumping;
        }
        else if (rb.velocity.y > .1f)
        {
            if (doubleJump2)
            {
                state = MovementState.doubleJump;
                doubleJump2 = false;
            }
            else state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            if (doubleJump2)
            {
                state = MovementState.doubleJump;
                doubleJump2 = false;
            }
            else state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    private void flip()
    {
        if (dirX < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (dirX > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void StopWallJump()
    {
        wallJumping = false;
    }
}
