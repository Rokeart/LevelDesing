using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public TogglePlatform platform; // referencia a la plataforma

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platform.ToggleMove();
            // Opcional: ac� pod�s cambiar la apariencia del bot�n (aplastarse, cambiar color, etc.)
        }
    }
}