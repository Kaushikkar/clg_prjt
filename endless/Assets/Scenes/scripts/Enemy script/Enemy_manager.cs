using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_manager : MonoBehaviour
{
    public List<Transform> enemyPrefabs = new List<Transform>();

    // Function to return a random enemy spawn point
    public Transform GetRandomEnemy()
    {
        // Check if the list is empty
        if (enemyPrefabs.Count == 0)
        {
            Debug.LogWarning("Enemy spawn points list is empty!");
            return null;
        }

        // Choose a random index within the range of the list
        int randomIndex = Random.Range(0, enemyPrefabs.Count);

        // Return the transform at the randomly chosen index
        return enemyPrefabs[randomIndex];
    }
}
