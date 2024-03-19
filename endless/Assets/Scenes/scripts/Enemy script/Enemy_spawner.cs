using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public Enemy_manager manager;
    public List<Transform> enemySpawnPoints = new List<Transform>(); // List of enemy spawn points

    public int numberOfEnemiesToSpawn = 5; // Number of enemies to spawn
    private int randomize;
    void Start()
    {
        // Check if the manager and spawn points are assigned
        if (manager == null || enemySpawnPoints.Count == 0)
        {
            Debug.LogError("Enemy manager or enemy spawn points are not assigned!");
            return;
        }

        // Spawn enemies
        SpawnEnemies(numberOfEnemiesToSpawn);
    }

    void SpawnEnemies(int numberOfEnemies)
    {
        randomize = Random.Range(1, numberOfEnemies);
        for (int i = 0; i < randomize; i++)
        {
            // Get a random enemy prefab from the manager
            Transform enemyPrefab = manager.GetRandomEnemy();

            // Check if an enemy prefab is retrieved
            if (enemyPrefab == null)
            {
                Debug.LogError("No enemy prefab found in the manager!");
                return;
            }

            // Get a random spawn point
            Transform spawnPoint = GetRandomSpawnPoint();

            // Check if a spawn point is retrieved
            if (spawnPoint == null)
            {
                Debug.LogError("No enemy spawn point found!");
                return;
            }

            // Instantiate the enemy prefab at the chosen spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    Transform GetRandomSpawnPoint()
    {
        // Choose a random index within the range of the spawn points list
        int randomIndex = Random.Range(0, enemySpawnPoints.Count);

        // Return the transform at the randomly chosen index
        return enemySpawnPoints[randomIndex];
    }
}