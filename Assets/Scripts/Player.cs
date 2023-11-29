using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Animator animator;
    float hMove;
    Vector2 dir;

    [SerializeField] float speed = 10;
    [SerializeField] float jump = 9f;
    [SerializeField] AudioClip[] audioGame;
    AudioSource audioSource;

    Rigidbody2D rb;
    bool isGrounded = false;
    bool isFacingRight = true;
    bool isMovementEnabled = true; 
    bool isJumpingEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        //rigidbody
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(hMove));
        MovingPlayer();
        //JumpingPlayer();
        FlipCharacter();
    }


    public void CoinColl()
    {
        audioSource.clip = audioGame[2];
        audioSource.Play();
    }

    public void EnemyColl()
    {
        audioSource.clip = audioGame[1];
        audioSource.Play();
    }

    public void MovingPlayer()
    {
        if (isMovementEnabled)
        { 
            hMove = Input.GetAxis("Horizontal");
            dir = new Vector2(hMove, 0);

            // Use Rigidbody2D for physics-based movement
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);

            // Update the animator's Speed parameter
            animator.SetFloat("Speed", Mathf.Abs(hMove));
        }
        if (isJumpingEnabled)
        {
            if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
            {
                rb.velocity = new Vector2(0, 1) * jump;
                animator.SetBool("IsJumping",true);
                audioSource.clip = audioGame[0];
                audioSource.Play();
                Debug.Log("jump");
            }
        }
    }

    public void SetMovementEnabled(bool isEnabled)
    {
        isMovementEnabled = isEnabled;
        isJumpingEnabled = isEnabled;
    }

   /* void JumpingPlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.velocity = new Vector2(0, 1) * jump;
            animator.SetBool("IsJumping", true);
            audioSource.clip = audioGame[0];
            audioSource.Play();
        }
    }*/

    void FlipCharacter()
    {
        // Ubah arah karakter jika bergerak ke kiri atau kanan
        if ((hMove > 0 && !isFacingRight) || (hMove < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ular") // Assuming "Ular" is the tag of your snake/enemy
        {
            // Player is touching the enemy, do whatever you want (e.g., player dies)
            SceneManager.LoadScene("gameplay");
            // Add your player death logic here
        }
        else if (other.tag == "Ground")
        {
            // Code for when player touches the ground
            animator.SetBool("IsJumping", false);
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
