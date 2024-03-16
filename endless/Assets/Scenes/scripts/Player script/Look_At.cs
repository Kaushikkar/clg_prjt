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
            //Debug.Log("looking");
            LookAtObject(lookAt);
        }
        else
        {



            Quaternion targetRotation = initialRotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void LookAtObject(GameObject target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);


        transform.rotation = lookRotation;
    }
}