using UnityEngine;
using TMPro;
using Platformer.Mechanics;

namespace Platformer.UI
{
    public class CookieUI : MonoBehaviour
    {
        public TokenController tokenController;
        public TextMeshProUGUI cookieText;

        void Update()
        {
            if (tokenController != null && cookieText != null)
            {
               
                cookieText.text = $"Cookies: {tokenController.collectedTokens}/{tokenController.totalTokens}";
            }
        }
    }
}

