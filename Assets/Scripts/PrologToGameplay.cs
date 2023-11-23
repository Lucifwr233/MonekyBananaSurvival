using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologToGameplay : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
