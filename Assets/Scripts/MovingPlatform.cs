using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveDirection { Horizontal, Vertical } // 👉 opciones
    public MoveDirection direction = MoveDirection.Horizontal;

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
        rb.isKinematic = true;
        lastPos = startPos;
    }

    void FixedUpdate()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        Vector3 newPos = startPos;

        // 👉 Cambiamos el eje según lo que elegiste en el Inspector
        if (direction == MoveDirection.Horizontal)
            newPos += new Vector3(offset, 0f, 0f);
        else
            newPos += new Vector3(0f, offset, 0f);

        rb.MovePosition(newPos);

        // calcular velocidad de la plataforma
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
                Vector2 playerVel = playerRb.linearVelocity;

                if (direction == MoveDirection.Horizontal)
                    playerRb.linearVelocity = new Vector2(velocity.x, playerVel.y);
                else // Vertical
                    playerRb.linearVelocity = new Vector2(playerVel.x, velocity.y);
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
                Vector2 playerVel = playerRb.linearVelocity;

                if (direction == MoveDirection.Horizontal)
                    playerRb.linearVelocity = new Vector2(0, playerVel.y);
                else
                    playerRb.linearVelocity = new Vector2(playerVel.x, 0);
            }
        }
    }
}