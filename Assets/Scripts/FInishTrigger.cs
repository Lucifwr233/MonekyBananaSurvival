#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class FInishTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource Winsfx;


    public delegate void FinishEvent();
    public static event FinishEvent OnFinish;

    #if UNITY_EDITOR
    [MenuItem("Window/Unlock Level +1")]
    #endif
    static void UnlockOneLevel()
    {
        UnlockNewLevel();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Winsfx.Play();
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
