using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public LayerMask whatIsPlayer;
    public float speed;
    public float rotationSpeed = 5f;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange)
            ChasePlayer();
    }

    void ChasePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;  // Ignore the y component to avoid tilting
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Move towards the player
        Vector3 newPosition = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Check for obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, sightRange))
        {
            if (hit.collider.CompareTag("Obstacles"))
            {
                // Avoid the obstacle
                Vector3 avoidanceDirection = Vector3.Cross(Vector3.up, directionToPlayer.normalized);
                newPosition += avoidanceDirection * speed * Time.deltaTime;
            }
        }

        // Update position
        transform.position = newPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
