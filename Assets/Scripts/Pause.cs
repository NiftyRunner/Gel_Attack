using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuItems;
    
    public static bool isPaused = false;
    

    void Start()
    {
        pauseMenuItems.SetActive(false);
        isPaused = false;
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false && PlayerHealth.isDead == false)
        {
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            ResumeGame();
        }    
    }

    public void PauseGame ()
    {
        isPaused = true;
        Debug.Log("Pause Working");
        pauseMenuItems.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        isPaused = false;
        Debug.Log("Resume Working");
        pauseMenuItems.SetActive(false);
        Time.timeScale = 1;
    }

}
