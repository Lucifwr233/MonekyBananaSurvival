using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FInishTrigger : MonoBehaviour
{

    public delegate void FinishEvent();
    public static event FinishEvent OnFinish;

    [MenuItem("Window/Unlock Level +1")]
    static void UnlockOneLevel()
    {
        UnlockNewLevel();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UnlockNewLevel();
            PauseMenu.GameIsFinished = true;
        }
    }

    static void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
