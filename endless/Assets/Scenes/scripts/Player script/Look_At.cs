using UnityEngine;

public class LookAt : MonoBehaviour
{
    public EnemyDetection enemyDetection;
    public float rotationSpeed = 10f;
    public float maxRotationAngle = 45f;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        GameObject lookAt = enemyDetection.closestEnemy;
        
        if (lookAt != null)
        {
            //Debug.Log("look activated");
            lookAtObject(lookAt);
        }
        else
        {
            //Debug.Log("initial activated");
            initRotation();
        }
    }

    void lookAtObject(GameObject target)
    {
        
        Vector3 directionToTarget = target.transform.position - transform.position;
        directionToTarget.y = 0f; // Ensure rotation only happens on the horizontal plane
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

        // Only rotate around the Y-axis
        transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
    }
    void initRotation()
    {
        transform.rotation= Quaternion.Euler(0f,initialRotation.eulerAngles.y, 0f);
    }
}
