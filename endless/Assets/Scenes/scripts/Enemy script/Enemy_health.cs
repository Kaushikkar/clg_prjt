using System.Collections;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    public int enemHealth; // Set the initial health in the inspector
    public int remainingHealth;
    public int damage = 1; // Assuming you want to deal damage to the enemy when hit
    public Enem_animC Anim;

    void Start()
    {
        remainingHealth = enemHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Decrease enemy health based on the damage value
            remainingHealth -= damage;

            // Check if the enemy has run out of health
            if (remainingHealth <= 0)
            {
                if (Anim != null)
                {
                    Anim.deathAnim();
                    StartCoroutine(Dead());
                }
                else
                {
                    // Handle the case where Anim is null (e.g., log a message)
                    Debug.LogWarning("Anim is null!");
                }

                // Destroy the entire bullet GameObject after enemy death
                Destroy(collision.gameObject);
            }
            else
            {
                // If the enemy is not dead, only destroy the bullet
                Destroy(collision.gameObject);
            }
        }
    }

    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }
}
