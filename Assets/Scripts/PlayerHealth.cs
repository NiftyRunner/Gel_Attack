using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float hitPoints = 10f;
    [SerializeField] float damage = 1f;
    [SerializeField] GameObject EndScreen;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip damageClip;
    [SerializeField] AudioSource playerAudioSource;

    public TextMeshProUGUI health;
    PlayerMove playerMove;
    Animator animator;

    public static bool isDead = false;

    void Start()
    {
        isDead = false;
        EndScreen.SetActive(false);
        health.text = new string("" + hitPoints);
        playerMove = FindObjectOfType<PlayerMove>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Enemy" && isDead == false)
        {
            if(hitPoints > 1)
            {
                playerAudioSource.PlayOneShot(damageClip);
                hitPoints = hitPoints-damage;
                health.text = new string("" + hitPoints);
            }
            else if(hitPoints == 0)
            {   
                isDead = true;
                health.text = new string("0");
                playerMove.enabled = false;
                animator.SetTrigger("Death");
                Destroy(gameObject, 1f);
                EndScreen.SetActive(true);
                playerAudioSource.PlayOneShot(deathClip);
            }
            else
            {
                isDead = true;
                health.text = new string("0");                
                playerMove.enabled = false;
                animator.SetTrigger("Death");
                Destroy(gameObject, 1f);
                EndScreen.SetActive(true);
                playerAudioSource.PlayOneShot(deathClip);
            }
            
        }    
    
    }
}
