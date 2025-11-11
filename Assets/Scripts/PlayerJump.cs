using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        Debug.Log(isGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
