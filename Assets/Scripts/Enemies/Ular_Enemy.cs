using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ular_Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private float damage;
    [SerializeField] private float moveDistance = 5f; // Jarak total yang akan ditempuh ular
    private Vector3 initialPosition;
    private float direction = 1; // 1 untuk gerakan ke kanan, -1 untuk gerakan ke kiri
    private SpriteRenderer spriteRenderer;

    private bool isMoving = false;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start moving when the enemy is within camera view
        StartCoroutine(ActivateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        // Hitung perpindahan ular
        float displacement = moveSpeed * Time.deltaTime * direction;

        // Pindahkan ular
        transform.Translate(new Vector3(displacement, 0, 0));

        // Flip sprite secara horizontal sesuai arah pergerakan
        if (displacement > 0)
        {
            FlipSprite(true); // Flip to the right
        }
        else if (displacement < 0)
        {
            FlipSprite(false); // Flip to the left
        }

        // Periksa apakah ular telah mencapai batas jarak, dan jika ya, ubah arah
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= moveDistance / 2)
        {
            // Ubah arah pergerakan
            direction *= -1;
        }
    }

    private void FlipSprite(bool facingRight)
    { 
        spriteRenderer.flipX = facingRight;
    }

    IEnumerator ActivateEnemy()
    {
        // Wait until the enemy is within the camera view
        yield return new WaitUntil(() => IsVisibleFromCamera());

        // Start moving
        isMoving = true;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            // Check if the player is touching the enemy's head (feet of the player touching head of the enemy)
            if (player.transform.position.y > transform.position.y)
            {
                // Player's feet are above the enemy's head, destroy the enemy
                Destroy(gameObject);
            }
            else
            {
                // Player touched the enemy, do whatever you want (e.g., damage the player)
                player.GetComponent<Health>().TakeDamage(damage);
            }
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
