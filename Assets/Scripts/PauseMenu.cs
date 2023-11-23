using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject InGameUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             if (GameIsPaused)
             {
                 Resume();
             }
             else
             {
                 Pause();
             }
        }
    }

    public void PressIconPause()
    {
        Pause();
    }

    public void Resume ()
    {
        InGameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        InGameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
