using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] AudioClip[] audioGame;

    public GameObject MainMenuUI;
    public GameObject AboutUI;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioGame[0];
        audioSource.Play();
    }
    public void OnPlayButton()
    {
        PauseMenu.GameIsFinished = false;
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("LevelSelection");
    }

    public void OnSettingButton()
    {
        MainMenuUI.SetActive(false);
        AboutUI.SetActive(true);

    }


    public void BacktoMenu()
    {
        MainMenuUI.SetActive(true);
        AboutUI.SetActive(false);
    }

    public void DeleteSaveGame()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
