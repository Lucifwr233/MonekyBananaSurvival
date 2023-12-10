using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentCheckpoint;
    public Transform[] chekpoints;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Load()
    {
        currentCheckpoint = PlayerPrefs.GetInt("Checkpoint");
    }
}
