using UnityEngine;

namespace Platformer.Mechanics
{
    public class TokenController : MonoBehaviour
    {
        public SimpleToken[] tokens;

        [Tooltip("Cantidad total inicial de tokens, aunque algunos estén inactivos al inicio.")]
        public int initialTotalTokens = 14;

        public int totalTokens { get; private set; }
        public int collectedTokens { get; private set; }

        void Awake()
        {
            if (tokens == null || tokens.Length == 0)
                tokens = FindObjectsOfType<SimpleToken>();

            foreach (var token in tokens)
            {
                if (token != null)
                    token.controller = this;
            }

            // Establecemos el total de tokens desde el valor fijo
            totalTokens = initialTotalTokens;
            collectedTokens = 0;
        }

        public void RegisterTokenCollected()
        {
            collectedTokens++;

           
        }
    }
}