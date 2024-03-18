using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField] int levelToBeLoaded;
    [SerializeField] GameObject creditTexts;
    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject controlTexts;
    [SerializeField] Pause pause;
    

    void Start() 
    {
        if(creditTexts != null && menuButtons != null)
        {
            controlTexts.SetActive(false);
            creditTexts.SetActive(false);
            menuButtons.SetActive(true);
        }     
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToBeLoaded);
    }

    public void LoadMainMenu()
    {
        pause.ResumeGame(); 
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {   
        creditTexts.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void LoadMainMenuByBackButton()
    {
        creditTexts.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void LoadControls()
    {
        controlTexts.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void LoadMenuFromBackButtonFromControls()
    {
        controlTexts.SetActive(false);
        menuButtons.SetActive(true);
    }
}
