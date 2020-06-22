using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriterenderer;
    Rigidbody2D rb2d;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;
    
    //Variables for horizontal & vertical movement
    private float movementSpeed = 7;
    private float jumpSpeed = 9;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate() {

        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        //Movement
        if (Input.GetKey("d")) 
        {
            rb2d.velocity = new Vector2(movementSpeed, rb2d.velocity.y);
            if(isGrounded)
             animator.Play("player-walk");
            spriterenderer.flipX = false;        
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-movementSpeed, rb2d.velocity.y);
            if(isGrounded)
             animator.Play("player-walk");
            spriterenderer.flipX = true;

        }
        else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            if(isGrounded)
             animator.Play("player-idle");

        }

        //Jump
        if (Input.GetKey("space") && isGrounded) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("player-jump");
        }
    }
}
