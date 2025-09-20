using Platformer.Mechanics;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float bounceForce = 15f;
    public AudioClip bounceSound; // sonido al rebotar

    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Aseguramos que haya un AudioSource en el objeto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
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
                    animator.SetTrigger("Bounce");

                // reproduce el sonido
                if (bounceSound != null)
                    audioSource.PlayOneShot(bounceSound);
            }
        }
    }
}

