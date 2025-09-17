using Platformer.Mechanics;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float bounceForce = 15f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController rb = other.gameObject.GetComponent<PlayerController>();
            if (rb != null)
            {
                // impulso hacia arriba
                rb.velocity.y = bounceForce;

                // dispara la animación de resorte
                if (animator != null)
                {
                    animator.SetTrigger("Bounce");
                }
            }
        }
    }
}

