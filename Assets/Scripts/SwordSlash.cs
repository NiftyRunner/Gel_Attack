using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    [SerializeField] float moveMultiplier;
    [SerializeField] float destroyTime = 0.5f;

    Rigidbody2D rb;

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(new Vector2(moveMultiplier, 0f), ForceMode2D.Impulse);
    }

    void Update()
    {
        // transform.Translate(transform.position + Vector3.right * moveMultiplier);
        
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }    
    }
}
