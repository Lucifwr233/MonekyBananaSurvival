using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    CapsuleCollider2D capsuleCollider2d;
    public Animator animator;
    public LayerMask groundLayer;
    public float radius;
    float hMove;
    Vector2 dir;

    [SerializeField] float speed = 10;
    [SerializeField] float jump = 9f;
    [SerializeField] public AudioSource walksfx;
    [SerializeField] public AudioSource coinsfx;
    [SerializeField] public AudioSource jumpsfx;
    [SerializeField] public AudioSource healthsfx;

    Rigidbody2D rb;
    //bool isGrounded = false;
    bool isFacingRight = true;
    bool isMovementEnabled = true;
    bool isJumpingEnabled = true;
    bool jumpInProgress = false;


    // Start is called before the first frame update
    void Start()
    {
        //rigidbody
        rb = GetComponent<Rigidbody2D>();
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


    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, radius, groundLayer);
        if (hit.collider != null)
        {

            Debug.DrawRay(transform.position, Vector2.down * radius, Color.green);
            Debug.Log("Ground detected!");
            return true;

        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * radius, Color.red);
            return false;
        }
    }


    public void CoinColl()
    {
        coinsfx.Play();
    }

    public void HealthColl()
    {
        healthsfx.Play();
    }

    public void EnemyColl()
    {

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
            // Play walksfx only when the player is moving horizontally
            if (hMove != 0)
            {
                if(!walksfx.isPlaying) 
                { 
                    walksfx.Play();
                }    
            }
            else
            {
                walksfx.Stop();
            }
        }
        if (isJumpingEnabled)
        {
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
            {
                rb.velocity = new Vector2(0, 1) * jump;
                jumpsfx.Play();
                jumpInProgress = true;
                return;
            }
        }
        if (jumpInProgress == true)
        {
            animator.SetBool("IsJumping", true);
        }
        if (jumpInProgress && rb.velocity.y < 0.1f)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
            Debug.Log("IsFalling");
        }
        if (jumpInProgress && IsGrounded())
        {
            HasLanded();
            return;
        }
        Debug.Log(IsGrounded());

    }

    void HasLanded()
    {
        animator.SetBool("IsFalling", false);
        animator.SetBool("IsJumping", false);
        jumpInProgress = false;
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
            
        }
        /*else if (other.tag == "Ground")
        {
            // Code for when player touches the ground
            animator.SetBool("IsJumping", false);
            isGrounded = true;
        }*/
    }

    /*private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Ground")
        {
            isGrounded = false;
        }
    }*/
}
