using UnityEngine;
using System;

public class ButtonToggle : MonoBehaviour
{
    public TogglePlatform platform;   // referencia a la plataforma
    public AudioClip pressSound;      // sonido al presionar
    public AudioClip releaseSound;    // sonido al soltar
    private Animator animator;
    private AudioSource audioSource;

    private bool isPressed = false; // bandera para evitar múltiples sonidos

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Aseguramos que haya un AudioSource en el botón
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        // Nos suscribimos al evento de la plataforma
        platform.OnPlatformStopped += ResetButton;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;

            if (animator != null)
                animator.SetBool("Pressed", true); // Cambia a animación de presionado

            // Reproduce sonido de presionar
            if (pressSound != null)
                audioSource.PlayOneShot(pressSound);

            platform.ToggleMove();
        }
    }

    private void ResetButton()
    {
        if (animator != null)
            animator.SetBool("Pressed", false); // Volvemos a idle

        // Reproduce sonido de soltar
        if (releaseSound != null)
            audioSource.PlayOneShot(releaseSound);

        isPressed = false;
    }
}