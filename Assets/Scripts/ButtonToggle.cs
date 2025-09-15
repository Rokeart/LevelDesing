using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public TogglePlatform platform; // referencia a la plataforma

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platform.ToggleMove();
            // Opcional: acá podés cambiar la apariencia del botón (aplastarse, cambiar color, etc.)
        }
    }
}