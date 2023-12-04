using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peluru_Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private float damage;

    private bool isMoving = false;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // Start moving when the enemy is within camera view
        StartCoroutine(ActivateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move horizontally using Mathf.PingPong for automatic back-and-forth movement
            float movement = Mathf.PingPong(Time.time * moveSpeed, 5) - 4f; // PingPong between -1 and 1
            transform.Translate(Vector2.right * movement * Time.deltaTime);
        }
    }

    IEnumerator ActivateEnemy()
    {
        // Wait until the enemy is within the camera view
        yield return new WaitUntil(() => IsVisibleFromCamera());

        // Start moving
        isMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.contacts[0].normal.y > 0.5)
        {
            // Player is touching the top of the enemy, destroy the enemy

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Player touched the enemy, do whatever you want (e.g., destroy the enemy
            collision.GetComponent<Health>().TakeDamage(damage);

        }
    }





    private bool IsVisibleFromCamera()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        Collider2D collider = GetComponent<Collider2D>();

        // Check if any part of the enemy is within the camera's view
        return GeometryUtility.TestPlanesAABB(planes, collider.bounds);
    }
}