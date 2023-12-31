using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] AudioClip[] audioGame;
    AudioSource audioSource;
    public Button[] buttons;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.GameIsOver = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioGame[0];
        audioSource.Play();
    }

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        if (levelId == 1)
        {
            // If the selected level is 1, go to prolog
            SceneManager.LoadScene("Prologue");
        }
        else
        {
            // If the selected level is greater than 1, go to gameplay
            string levelName = "Gameplay" + levelId;
            SceneManager.LoadScene(levelName);
        }
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
