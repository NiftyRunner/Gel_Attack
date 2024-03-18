using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bgAudio;
    [SerializeField] AudioClip deathClip;

    bool bgStopped = false;

    void Start()
    {
        audioSource.Play();
    }

    void Update()
    {
        if(PlayerHealth.isDead == true && bgStopped == false && deathClip != null)
        {
            bgStopped = true;
            audioSource.Stop();
            Debug.Log("Stop");
            audioSource.PlayOneShot(deathClip);
        }
    }
}
