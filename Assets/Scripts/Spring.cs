using Platformer.Mechanics;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float bounceForce = 15f;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
          
            PlayerController rb = other.gameObject.GetComponent<PlayerController>();
            if (rb != null)
            {
                                        
                rb.velocity.y = bounceForce;

            }
        }
    }
}

