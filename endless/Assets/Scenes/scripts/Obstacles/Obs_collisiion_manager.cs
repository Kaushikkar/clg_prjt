using UnityEngine;

public class Obs_collision_manager : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles") )
        {
            // Destroy the current obstacle when colliding with another obstacle
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(gameObject.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
