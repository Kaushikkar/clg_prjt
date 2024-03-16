using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer, whatIsEnemy;
    private Enemy_health health;
    public float speed;
    public float rotationSpeed = 5f;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // States
    public float sightRange, attackRange, separationDistance, separationStrength;
    public bool playerInSightRange, playerInAttackRange;

    private Collider enemyCollider;

    private void Start()
    {
        health= GetComponent<Enemy_health>();
        enemyCollider = GetComponent<Collider>();

        if (enemyCollider == null)
        {
            Debug.LogError("Collider component not found on the enemy GameObject!");
        }
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //Debug.Log(health.remainingHealth);
        if (playerInSightRange && !playerInAttackRange && health.remainingHealth>=-3) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && health.remainingHealth >= -3) AttackPlayer();
    }

    void ChasePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;  // Ignore the y component to avoid tilting
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Reset the y-component of the position to 0
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        // Ignore collisions with other objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, sightRange, whatIsEnemy);
        foreach (Collider otherEnemyCollider in colliders)
        {
            if (otherEnemyCollider != enemyCollider)
            {
                Vector3 separationDirection = transform.position - otherEnemyCollider.transform.position;
                transform.position += separationDirection.normalized * separationStrength * Time.deltaTime;
            }
        }
    }


    void AttackPlayer()
    {
        // Attack logic here
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
