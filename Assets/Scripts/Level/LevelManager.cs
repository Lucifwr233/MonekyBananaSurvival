using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int totalCoin;
    public int currentLevel;
    public int[] coinNeeded;
    public UnityEvent coinPickup;

    bool goNextLevel;

    private void Awake()
    {
         instance = this;
            
    }

    public void CoinCheck()
    {
        if (currentLevel == 1) 
        { 
            if(totalCoin >= coinNeeded[0])
            {
                goNextLevel = true;
            }
            else
            {
                goNextLevel = false;
            }
        }
                if (currentLevel ==2)
                {
                    if (totalCoin >= coinNeeded[1])
                    {
                        goNextLevel = true;
                    }
                    else
                    {
                        goNextLevel = false;
                    }
                }
                    if (currentLevel == 3)
                    {
                        if (totalCoin >= coinNeeded[2])
                        {
                            goNextLevel = true;
                        }
                        else
                        {
                            goNextLevel = false;
                        }
                    }

    }

    public void FinisedLevel()
    {
        ResetCoin();
        SceneManager.LoadScene("LevelSelection");
    }


    public int TotalCoin
    {
        get{
            return totalCoin;
        }
        set{
            totalCoin = value;
            CoinCheck();
            coinPickup?.Invoke();
        }
    }

    public void ResetCoin()
    {
        totalCoin = 0;
    }




    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
