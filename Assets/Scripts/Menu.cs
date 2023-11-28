using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] AudioClip[] audioGame;
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
        SceneManager.LoadScene("Gameplay");
    }

    public void OnAboutButton()
    {
        SceneManager.LoadScene("About");
        audioSource.clip = audioGame[0];
        audioSource.Play();
    }


    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
