using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public SimpleToken token;

        public override void Execute()
        {
            // Reproducir audio si existe
            if (token != null && token.tokenCollectAudio != null)
                AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);

            // Aquí podés agregar efectos extra si querés
        }
    }
}