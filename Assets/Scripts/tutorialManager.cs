using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialManager : MonoBehaviour
{

    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorial5;
    public GameObject tutorial6;
    [SerializeField] AudioClip[] audioGame;
    AudioSource audioSource;

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

    public void btntutorial1()
    {
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
    }
    public void btntutorial2()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
        tutorial6.SetActive(false);
    }
    public void btntutorial3()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(true);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
        tutorial6.SetActive(false);
    }
    public void btntutorial4()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(true);
        tutorial5.SetActive(false);
        tutorial6.SetActive(false);
    }
    public void btntutorial5()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(true);
        tutorial6.SetActive(false);
    }
    public void btntutorial6()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
        tutorial6.SetActive(true);
    }
    public void loadtolevel1()
    {
        SceneManager.LoadScene("Gameplay1");
    }
}
