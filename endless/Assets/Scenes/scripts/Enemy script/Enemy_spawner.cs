using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public Enemy_manager manager;
    public List<Transform> enemySpawnPoints = new List<Transform>(); // List of enemy spawn points

    public int numberOfEnemiesToSpawn = 5; // Number of enemies to spawn
    public bool spawnAgain;
    public Cont_obsSpawner spawner;
    void Start()
    {
        // Check if the manager and spawn points are assigned
        if (manager == null || enemySpawnPoints.Count == 0)
        {
            Debug.LogError("Enemy manager or enemy spawn points are not assigned!");
            return;
        }
        spawner = GetComponent<Cont_obsSpawner>();
        // Spawn enemies
        SpawnEnemies(numberOfEnemiesToSpawn);
    }
    private void Update()
    {
        //int i = 1;
        if (spawner.changed)
        {
            //Debug.Log("Enemy spawned again" + i++);
            SpawnEnemies(numberOfEnemiesToSpawn);
        }
    }
    void SpawnEnemies(int numberOfEnemies)
    {
        // Create a copy of the original spawn points list
        List<Transform> availableSpawnPoints = new List<Transform>(enemySpawnPoints);

        // Ensure we don't spawn more enemies than available spawn points
        int spawnCount = Mathf.Min(numberOfEnemies, availableSpawnPoints.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            // Get a random enemy prefab from the manager
            Transform enemyPrefab = manager.GetRandomEnemy();

            // Check if an enemy prefab is retrieved
            if (enemyPrefab == null)
            {
                Debug.LogError("No enemy prefab found in the manager!");
                return;
            }

            // Get a random spawn point from the available spawn points
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform spawnPoint = availableSpawnPoints[randomIndex];

            // Generate a random rotation
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Instantiate the enemy prefab at the chosen spawn point with random rotation
            Instantiate(enemyPrefab, spawnPoint.position, randomRotation * spawnPoint.rotation);

            // Remove this spawn point from the available spawn points list to avoid reusing it
            availableSpawnPoints.RemoveAt(randomIndex);
        }
    }
}
