using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMusic : MonoBehaviour
{

    [SerializeField] AudioClip[] audioGame;
    public AudioSource audioSource { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioGame[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
