using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_projectileImpact : MonoBehaviour
{
    public int delay;
    public GameObject explosionVfxPrefab;
    public AudioClip explosionSound; // Audio clip to play on impact
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject, delay);
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameObject explosionVfx = Instantiate(explosionVfxPrefab, collision.contacts[0].point, Quaternion.identity);

            // Play explosion sound
            AudioSource.PlayClipAtPoint(explosionSound, collision.contacts[0].point);

            Destroy(explosionVfx, delay); // Destroy the instantiated explosion VFX after delay
            Destroy(gameObject); // Destroy the projectile immediately
        }
    }
}
