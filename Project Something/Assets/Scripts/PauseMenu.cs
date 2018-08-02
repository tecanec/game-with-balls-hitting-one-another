﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;
    public GameObject firstPauseMenu;
    public GameObject currentMenu;
    public AudioLowPassFilter pauseFilter;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

   public void Resume ()
   {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;

        if (pauseFilter) // Sluk low-pass filtret, når spillet fortsættes
            pauseFilter.enabled = false;
    }

   void Pause ()
   {
        ChangeMenu(firstPauseMenu);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;

        if (pauseFilter) // Tænd low-pass filtret, når spillet sættes på pause
            pauseFilter.enabled = true;
    }

    public void ChangeMenu(GameObject setTo)
    {
        if (setTo) setTo.SetActive(true);
        if (currentMenu) currentMenu.SetActive(false);
        currentMenu = setTo;
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

    public void LoadSelectlevel()
    {
        SceneManager.LoadScene("Selectlevel");
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

}




