using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public LayerMask whatIsPlayer;
    public float speed;
    public float rotationSpeed = 5f;
    public bool isBlocked;
    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, isDead;

    private void Update()
    {
        
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //Debug.Log(isBlocked);
        if (player != null && playerInSightRange && !playerInAttackRange && !isDead && isBlocked == false)
        {
            ChasePlayer();
        }
           
        else if (player != null && playerInAttackRange && !isDead&&isBlocked)
            AttackPlayer();
    }
    void ChasePlayer()
    {
        

        // Calculate direction to player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Ignore the y component to avoid tilting
        directionToPlayer.y = 0;

        // Rotate towards the player directly
        transform.rotation = Quaternion.LookRotation(directionToPlayer);

        // Move towards the player
        Vector3 newPosition = transform.position + transform.forward * speed * Time.deltaTime;

        // Update position
        transform.position = newPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Obstacles")
        {
            isBlocked = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            isBlocked = false;
        }
    }
    void AttackPlayer()
    {
        // Rotate towards the player directly
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        directionToPlayer.y = 0;
        transform.rotation = Quaternion.LookRotation(directionToPlayer);

        // Implement attack logic here
        // For example, you can trigger an attack animation or deal damage to the player
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
