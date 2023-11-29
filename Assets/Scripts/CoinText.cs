using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class CoinText : MonoBehaviour
{
    TextMeshProUGUI coinText;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void UpdateValue()
    {
        coinText.text = "Banana : " + LevelManager.instance.TotalCoin;
    }

    void OnEnable()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        UpdateValue();
        if (LevelManager.instance == null) return;
        LevelManager.instance.coinPickup.AddListener(UpdateValue);
    }

    void OnDisable() 
    {
        if (LevelManager.instance == null) return;
        LevelManager.instance.coinPickup.RemoveListener(UpdateValue);
    }
}
