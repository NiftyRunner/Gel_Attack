using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SheepInteraction : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float petRange = 1f;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator sheepAnimator;
    [SerializeField] float incrementHitPoint = 1f;
    [SerializeField] float newHitPoints;
    [SerializeField] float destroyTime = 10f;

    float distanceToPet = Mathf.Infinity;
    PlayerHealth playerHealth;
    public static bool isPetting = false;

    void Update()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        distanceToPet = Vector2.Distance(player.transform.position, transform.position);
        StartCoroutine(PetTimeOver());
    }

    IEnumerator PetTimeOver()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    void OnPet(InputValue value)
    {
        if(value.isPressed && !isPetting && distanceToPet<petRange)
        {
            isPetting = true;
            playerAnimator.SetTrigger("PettingSheep");
            sheepAnimator.SetTrigger("Pet");
            StartCoroutine(SetPettingBool());
        }
    }

    IEnumerator SetPettingBool()
    {
        yield return new WaitForSecondsRealtime(1f);
        isPetting = false;
        newHitPoints  = playerHealth.hitPoints + incrementHitPoint;
        playerHealth.health.text = new string("" + newHitPoints);
        playerHealth.hitPoints = newHitPoints;
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, petRange); 
    }
}
