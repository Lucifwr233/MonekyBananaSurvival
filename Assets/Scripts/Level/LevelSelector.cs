using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private string level1,level2,level3;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevel1(int value)
    {
        switch(value)
            {
            case 0:
                SceneManager.LoadScene(level1);
                break; 
            case 1:
                SceneManager.LoadScene(level2);
                break; 
            case 2:
                SceneManager.LoadScene(level3);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
