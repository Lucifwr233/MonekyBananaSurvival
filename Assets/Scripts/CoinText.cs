using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class CoinText : MonoBehaviour
{
    public int coinTotal = 0;
    TextMeshProUGUI coinText;


    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //if (coinTotal >= 10)
        //{
          //  SceneManager.LoadScene(0);
       // }
    }

    public void AddScore()
    {
        coinTotal++;
        coinText.text = "Banana : " + coinTotal;
    }
}
