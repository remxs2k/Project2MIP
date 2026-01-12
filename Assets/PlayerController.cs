using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int extraJumps = 1;     // Set to 1 for Double Jump
    private int jumpsLeft;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = extraJumps; // Initialize jumps at start
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // --- UPDATED JUMP INPUT LOGIC ---
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump(); // Jump from ground
            }
            else if (jumpsLeft > 0)
            {
                Jump(); // Jump from air
                jumpsLeft--; // Decrease counter
            }
        }

        if (transform.position.y < -1.5f)
        {
            Debug.Log("I have fallen!"); 

            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                Debug.Log("ERROR: GameManager is missing!");
            }

            Destroy(gameObject);
        }
    }

    // --- NEW FUNCTION FOR DOUBLE JUMP ---
    void Jump()
    {
        // We set Y velocity directly to ensure the second jump is snappy
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    // Simple Ground Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpsLeft = extraJumps; // RESET JUMPS ON LANDING
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}