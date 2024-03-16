using UnityEngine;

public class Health_Manager : MonoBehaviour
{
    public int health;
    public float cooldown=2;
    private bool isHitCooldown = false;
    public bool isCollided;
    public void ReduceHealth()
    {
        if (!isHitCooldown)
        {
            health--;
            isHitCooldown = true;
            Invoke("ResetHitCooldown", cooldown); // Adjust the cooldown duration as needed
        }
    }
    private void ResetHitCooldown()
    {
        isHitCooldown = false;
    }
    
    private void OnCollisionEnter(Collision collision)
    {

        if ( collision.gameObject.tag == "Obstacles")
        {
            isCollided = true;
        }
        else if(collision.gameObject.tag=="Enemies")
        {
            ReduceHealth();
        }
    }
}