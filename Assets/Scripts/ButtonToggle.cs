using UnityEngine;
using System;

public class ButtonToggle : MonoBehaviour
{
    public TogglePlatform platform; // referencia a la plataforma
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Nos suscribimos al evento de la plataforma
        platform.OnPlatformStopped += ResetButton;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (animator != null)
                animator.SetBool("Pressed", true); // Cambia a animación de presionado

            platform.ToggleMove();
        }
    }

    private void ResetButton()
    {
        if (animator != null)
            animator.SetBool("Pressed", false); // Volvemos a idle
    }
}
