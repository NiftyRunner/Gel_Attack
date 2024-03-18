using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if(player != null)
        {
            StartCoroutine(MoveToPlayer());
            FlipSprite();
        }
    }

    IEnumerator MoveToPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        yield return new WaitForSeconds(1f);
        transform.Translate(direction * moveSpeed * Time.deltaTime);  
    }

    void FlipSprite()
    {
        
        bool enemyHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        int sign = player.transform.position.x > transform.position.x ? -1 : 1;
        transform.localScale = new Vector2(sign, 1f);    
    }
}
