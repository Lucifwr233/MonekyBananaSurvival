using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource Losesfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Losesfx.Play();
            LevelManager.instance.ResetCoin();
            PauseMenu.GameIsOver = true;
            //SceneManager.LoadScene("LevelSelection");
        }
    }
}
