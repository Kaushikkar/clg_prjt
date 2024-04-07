using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_projectileAttack : MonoBehaviour
{
    public EnemyAI ai;
    public Animator EnemyAnim;
    public GameObject ProjectilePrefab;
    public Transform bulletSpawnPoint;

    // Variables for projectile speed and angle
    public float projectileSpeed = 10f;
    public float angle = 45f;

    // Cooldown variables
    public float attackCooldown = 1f;
    public float delayBeforeAttack = 0.5f; // Add a delay before attacking
    private float cooldownTimer = 0f;
    private bool canAttack = true;
    private float delayTimer = 0f;
    private bool delayComplete = false;

    private void Update()
    {
        // Check if delay is complete
        if (!delayComplete)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= delayBeforeAttack)
            {
                delayComplete = true;
                delayTimer = 0f;
            }
        }

        // If delay is complete and player is in attack range and enemy can attack
        if (delayComplete && ai.playerInAttackRange && canAttack)
        {
            Attack();
            delayComplete = false; // Reset delay flag
        }
        else
        {
            // Start cooldown timer if not already cooling down
            if (!canAttack)
            {
                cooldownTimer += Time.deltaTime;
                if (cooldownTimer >= attackCooldown)
                {
                    cooldownTimer = 0f;
                    canAttack = true;
                }
            }
        }
    }

    void Attack()
    {
        EnemyAnim.SetBool("attackPlayer", true);

        // Instantiate the projectile
        GameObject newProjectile = Instantiate(ProjectilePrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Calculate the direction towards the player with some randomness
        Vector3 direction = (ai.player.transform.position - bulletSpawnPoint.position).normalized;
        direction += Random.insideUnitSphere * 0.2f; // Adjust the value as needed for randomness

        // Calculate the angle in radians
        float angleRad = angle * Mathf.Deg2Rad;

        // Calculate the velocity components
        float velocityX = projectileSpeed * Mathf.Cos(angleRad);
        float velocityY = projectileSpeed * Mathf.Sin(angleRad);

        // Set the velocity of the projectile
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(velocityX * direction.x, velocityY, velocityX * direction.z); // Adjusting for 3D

        // Set canAttack to false to start cooldown
        canAttack = false;
    }
}
