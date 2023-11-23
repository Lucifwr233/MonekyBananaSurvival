using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < transform.position.y)
        {
            col.enabled = false;
        }
        if (Player.transform.position.y > transform.position.y)
        {
            col.enabled = true;
        }

        if (Input.GetAxis("Vertical") <0)
        {
            col .enabled = false;
        }
    }
}
