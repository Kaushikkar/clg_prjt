using UnityEngine;

public class Obs_collision_manager : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles") || gameObject.transform.position.x<0)
        {
            // Destroy the current obstacle when colliding with another obstacle
            Destroy(gameObject);
        }
    }
}
