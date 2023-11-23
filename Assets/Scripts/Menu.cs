using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnAboutButton()
    {
        SceneManager.LoadScene("About");
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
