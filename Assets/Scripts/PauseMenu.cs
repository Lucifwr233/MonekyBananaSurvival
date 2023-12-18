using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;
    public static bool GameIsFinished = false;

    public GameObject pauseMenuUI;
    public GameObject GameOver;
    public GameObject InGameUI;
    public GameObject FinishUI;
    public GameObject CoinText;

    // Update is called once per frame
    void Update()
    {
        if (GameIsFinished)
        {
            finish();
        }
        else {
            if (GameIsOver)
            {
                gameover();
            }
            else
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
        }
    }

    public void PressIconPause()
    {
        Pause();
    }

    public void Resume()
    {
        InGameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameIsFinished = false;

        // Find the GameObject with the Player component
        Player player = FindObjectOfType<Player>();

        // Check if the Player component is found
        if (player != null)
        {
            player.SetMovementEnabled(true);
        }

        EnviromentMusic environmentMusic = FindObjectOfType<EnviromentMusic>();
        if (environmentMusic != null)
        {
            environmentMusic.audioSource.enabled = true;
        }
    }

    void Pause()
    {
        InGameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameIsFinished = false;

        // Find the GameObject with the Player component
        Player player = FindObjectOfType<Player>();

        // Check if the Player component is found
        if (player != null)
        {
            player.SetMovementEnabled(false);
        }

        EnviromentMusic environmentMusic = FindObjectOfType<EnviromentMusic>();
        if (environmentMusic != null)
        {
            environmentMusic.audioSource.enabled = false;
        }
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        GameOver.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        InGameUI.SetActive(true);
        GameOver.SetActive(false);
        GameIsOver = false;
        GameIsFinished = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }

    public void NextLevel()
    {
        //loadscene next level 
        FinishUI.SetActive(false);
        GameOver.SetActive(false);
        LevelManager.instance.FinisedLevel();
    }

    //gameover
    public void gameover()
    { 
        Time.timeScale = 0f;
        InGameUI.SetActive(false);
        GameOver.SetActive(true);
        EnviromentMusic environmentMusic = FindObjectOfType<EnviromentMusic>();
        if (environmentMusic != null)
        {
            environmentMusic.audioSource.enabled = false;
        }
    }



    public void finish()
    {
        Time.timeScale = 0f;
        GameOver.SetActive(false);
        InGameUI.SetActive(false);
        FinishUI.SetActive(true);
        GameIsFinished = true;
        EnviromentMusic environmentMusic = FindObjectOfType<EnviromentMusic>();
        if (environmentMusic != null)
        {
            environmentMusic.audioSource.enabled = false;
        }
    }

    public void finishToEpilog()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Epilog");
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameIsFinished = false;
        GameIsOver = false;
    }
}
