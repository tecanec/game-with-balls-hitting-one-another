using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;
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
        if (pauseFilter)
            pauseFilter.enabled = false;
    }

   void Pause ()
   {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        if (pauseFilter)
            pauseFilter.enabled = true;
    }

   public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
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

}




