using UnityEngine;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class PowerUpDoubleJump : MonoBehaviour
    {
        [Tooltip("Cantidad de saltos extra que otorga este power-up.")]
        public int extraJumps = 1;

        [Tooltip("Audio opcional al recoger.")]
        public AudioClip collectAudio;

        bool collected = false;

        void OnEnable()
        {
            // Si se reactiva el GameObject (respawn), permitir recoger de nuevo.
            collected = false;
        }

        void Awake()
        {
            // Asegurarse que el collider esté en modo Trigger para detectar al player
            var col = GetComponent<Collider2D>();
            if (col != null) col.isTrigger = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (collected) return;

            // buscamos el PlayerController en el objeto que colisionó
            var player = other.GetComponent<PlayerController>();
            if (player == null) return;

            collected = true;

            // aplicar el power-up: aumentar saltos máximos
            player.maxJumpCount += extraJumps;

            // reproducir audio en la posición del power-up (si hay uno)
            if (collectAudio != null)
                AudioSource.PlayClipAtPoint(collectAudio, transform.position);

            // desactivar el objeto (desaparece)
            gameObject.SetActive(false);
        }
    }
}