using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 10f;
    [SerializeField] float damage = 1f;
    [SerializeField] AudioClip damageClip;
    [SerializeField] AudioClip deathClip;


    [SerializeField] AudioSource enemyAudioSource;
    [SerializeField] GameObject enemyAudio;
    ScoreCount Score;
    public static bool isEnemyDead = false;
    Animator animator;
    BoxCollider2D enemyCollider;

    void Start()
    {
        enemyAudio = GameObject.FindWithTag("EnemyAudio");
        enemyAudioSource = enemyAudio.GetComponent<AudioSource>();
        Score = FindObjectOfType<ScoreCount>();
        enemyCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "SwordSlash" )
        {
            if(hitPoints > 1)
            {
                enemyAudioSource.PlayOneShot(damageClip);
                hitPoints = hitPoints-damage;
            }
            else
            {
                enemyAudioSource.PlayOneShot(deathClip);
                isEnemyDead = true;
                Score.scoreCount += 1;
                animator.SetTrigger("IsDead");
                Destroy(gameObject, 0.5f);
            }
            
        }    
    
    }
}
