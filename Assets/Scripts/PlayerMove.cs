using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float moveMultiplier = 10f;
    [SerializeField] float swordMoveMultiplier = 5;
    [SerializeField] Animator animator;
    [SerializeField] GameObject swordSlash;
    [SerializeField] Vector2 offset = new Vector2(1f,0f);
    [SerializeField] Transform spawnPos;
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioClip jumpClip;

    Vector2 spawnPosition;

    Vector2 jumpDistance;
    Vector2 jumpVelocity;
    bool isGrounded = true;

    Vector2 moveDistance; 
    Vector2 playerVelocity;

    bool isAttacking = false;
    
    Rigidbody2D rb;
    AudioSource playerAudioSource;

    void Start() 
    {
        playerAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        spawnPosition = new Vector2(offset.x + transform.position.x, offset.y + transform.position.y);   
        Run();
        FlipSprite();
    }

    public void OnMove(InputValue value)
    {
        //if(value.isPressed){animator.SetBool("Run", true);}
        //else{animator.SetBool("Run", false);}

        moveDistance = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        if(value.isPressed && !isAttacking && isGrounded)
        {
            playerAudioSource.PlayOneShot(attackClip);
            isAttacking = true;
            animator.SetTrigger("Attacking");
            GameObject slash = Instantiate(swordSlash, spawnPos.position, transform.rotation);
            int isRight = transform.localScale.x > 0 ? 1 : -1;
            slash.GetComponent<Rigidbody2D>().AddForce(new Vector2(swordMoveMultiplier * isRight, 0f), ForceMode2D.Impulse);
            slash.transform.localScale = new Vector3(isRight, 1, 1);
            StartCoroutine(AttackBoolSet());
        }
    }

    IEnumerator AttackBoolSet()
    {
        yield return new WaitForSecondsRealtime(1f);
        isAttacking = false;
    }

    void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Run", playerHasHorizontalSpeed);
        Vector2 playerVelocity = new Vector2 (moveDistance.x*moveMultiplier, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded && !isAttacking)
        {
            playerAudioSource.PlayOneShot(jumpClip);
            isGrounded = false;
            rb.velocity = new Vector2(0f, jumpForce);
            animator.SetTrigger("Jump");
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground") )
        {
            isGrounded = true;
        }    
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);    
        }
        
    }

}
