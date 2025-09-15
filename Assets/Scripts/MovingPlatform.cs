using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float amplitude = 3f;
    public float speed = 2f;

    private Vector3 startPos;
    private Rigidbody2D rb;
    private Vector3 lastPos;
    private Vector3 velocity;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // platform controlled by script
        lastPos = startPos;
    }

    void FixedUpdate()
    {
        float x = Mathf.Sin(Time.time * speed) * amplitude;
        Vector3 newPos = startPos + new Vector3(x, 0f, 0f);

        // Move with physics
        rb.MovePosition(newPos);

        // Calculate velocity
        velocity = (newPos - lastPos) / Time.fixedDeltaTime;
        lastPos = newPos;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Add platform velocity to the player
                Vector2 playerVel = playerRb.linearVelocity;
                playerRb.linearVelocity = new Vector2(velocity.x, playerVel.y);
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Add platform velocity to the player
                Vector2 playerVel = playerRb.linearVelocity;
                playerRb.linearVelocity = new Vector2(0, playerVel.y);
            }
        }
    }
}