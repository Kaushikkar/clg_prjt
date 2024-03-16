using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public string tagToDetect = "Enemy";
    public float detectionRadius = 10f;
    public GameObject[] allEnemies;
    public GameObject closestEnemy;
    public Vector3 offset;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position+offset, detectionRadius);
    }
    public bool enemiesFound = false;
    void Start()
    {
        UpdateAllEnemies();
    }

    void Update()
    {
        UpdateAllEnemies();
        closestEnemy = ClosestEnemy();
        //Debug.Log(enemiesFound);
    }

    void UpdateAllEnemies()
    {
        allEnemies = GameObject.FindGameObjectsWithTag(tagToDetect);
        List<GameObject> activeEnemies = new List<GameObject>();

        foreach (var enemy in allEnemies)
        {
            if (enemy.activeInHierarchy)
            {
                activeEnemies.Add(enemy);
            }
        }

        allEnemies = activeEnemies.ToArray();
    }

    GameObject ClosestEnemy()
    {
        GameObject closestHere = null;
        float leastDistance = Mathf.Infinity;

        foreach (var enemy in allEnemies)
        {
            float distanceHere = Vector3.Distance(transform.position + offset, enemy.transform.position);

            if (distanceHere < leastDistance)
            {
                leastDistance = distanceHere;
                closestHere = enemy;

            }
        }

        // Check if any enemy was found within the radius
        if (closestHere != null && leastDistance <= detectionRadius)
        {
            enemiesFound = true;
            return closestHere;
        }
        else
        {
            enemiesFound = false;
            return null; // Return null when no enemy is within the radius}

        }
    }
}
