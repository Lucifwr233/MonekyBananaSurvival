    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PU : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.CoinColl();
            LevelManager.instance.TotalCoin++;
            Destroy(this.gameObject);

        }
    }
}
