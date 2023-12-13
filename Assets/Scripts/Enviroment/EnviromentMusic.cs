using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnviromentMusic : MonoBehaviour
{
    [SerializeField] AudioClip[] audioGame;
    public AudioSource audioSource { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Get the current scene name
        string sceneName = SceneManager.GetActiveScene().name;

        // Determine which audio clip to play based on the scene
        AudioClip clipToPlay = GetAudioClipForScene(sceneName);

        // Set the selected audio clip and play it
        if (clipToPlay != null)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
    }

    // Method to map scene names to audio clips
    private AudioClip GetAudioClipForScene(string sceneName)
    {
        switch (sceneName)
        {
            case "Gameplay1":
                return audioGame[0];
            case "Gameplay2":
                return audioGame[1];
            // Add more cases for additional scenes as needed
            default:
                return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
