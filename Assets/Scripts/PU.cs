    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PU : MonoBehaviour
{
    [SerializeField] GameObject coinText;
    CoinText coinScript;

    Player player;
    [SerializeField] GameObject playerOBJ;
    // Start is called before the first frame update
    void Start()
    {
        coinScript = coinText.GetComponent<CoinText>();
        player = playerOBJ.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.CoinColl();
            coinScript.AddScore();
            Destroy(this.gameObject);
        }
    }
}
