using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject Players;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        Players = Player.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Players.transform.position.y < transform.position.y)
        {
            col.enabled = false;
        }
        if (Players.transform.position.y > transform.position.y)
        {
            col.enabled = true;
        }

        if (Input.GetAxis("Vertical") <0)
        {
            col .enabled = false;
        }
    }
}
