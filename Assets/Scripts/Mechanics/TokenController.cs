using UnityEngine;

namespace Platformer.Mechanics
{
    public class TokenController : MonoBehaviour
    {
        public SimpleToken[] tokens;

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

            totalTokens = tokens.Length;
            collectedTokens = 0;
        }

        public void RegisterTokenCollected()
        {
            collectedTokens++;
            
        }
    }
}