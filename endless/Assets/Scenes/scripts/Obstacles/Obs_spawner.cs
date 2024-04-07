using UnityEngine;
using System.Collections.Generic;

public class SpawnPointManager : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject objectToSpawn;
    public int maxObstacles;
    //public string obstacleTag = "Obstacles"; // Set the tag of your obstacles in the Unity Editor
    private List<Transform> unusedSp = new List<Transform>();
    public Obs_manager manager;

    void Start()
    {
        // Make a copy of spawnPoints to unusedSp to track available spawn points
        unusedSp.AddRange(spawnPoints);
        SpawnObjectsAtRandomPoints();
    }

    public void SpawnObjectsAtRandomPoints()
    {
        int totalObstaclesToSpawn = Random.Range(2, maxObstacles);

        for (int i = 0; i < totalObstaclesToSpawn; i++)
        {
            objectToSpawn = manager.Randomobs();

            if (unusedSp.Count > 0)
            {
                int randomIndex = GetRandomUnusedSpawnIndex();
                Transform randomSpawnPoint = unusedSp[randomIndex];

                // Generate a random rotation
                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

                // Instantiate the obstacle with random rotation
                GameObject spawnedObject = Instantiate(objectToSpawn, randomSpawnPoint.position, randomRotation);

                // Attach the spawned obstacle to the "Obstacle" tag
                //spawnedObject.tag = obstacleTag;
            }
            else
            {
                Debug.LogWarning("No spawn points available!");
                break; // Exit the loop if there are no spawn points left
            }
        }
    }

    // Get a random index from unusedSp that hasn't been used yet
    int GetRandomUnusedSpawnIndex()
    {
        int randomIndex = Random.Range(0, unusedSp.Count);
        return randomIndex;
    }
}
