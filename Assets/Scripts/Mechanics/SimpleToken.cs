using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class SimpleToken : MonoBehaviour
    {
        public AudioClip tokenCollectAudio;
        public TokenController controller;
        private bool collected = false;

       
        void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
                OnPlayerEnter(player);
        }

        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            collected = true;
            

            if (tokenCollectAudio != null)
                AudioSource.PlayClipAtPoint(tokenCollectAudio, transform.position);

            if (controller != null)
                controller.RegisterTokenCollected();
            
            
            var ev = Schedule<PlayerTokenCollision>();
            ev.player = player;
            ev.token = this;

            gameObject.SetActive(false);
        }
    }
}