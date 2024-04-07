using UnityEngine;
using System.Collections.Generic;

public class RandomObjectSelector : MonoBehaviour
{
    // Define a class to hold GameObject and its corresponding weight
    [System.Serializable]
    public class WeightedObject
    {
        public GameObject gameObject;
        public float weight;
    }

    // List of weighted objects
    public List<WeightedObject> weightedObjects = new List<WeightedObject>();

    // Time variables for random instantiation
    public float initialDelay = 300f; // 5 minutes in seconds
    public float minInterval = 5f; // Minimum interval between instantiations
    public float maxInterval = 10f; // Maximum interval between instantiations
    private float timer;
    private bool hasStarted = false;
    public GameObject selectedObject;
    // Function to select a random object based on weights
    public GameObject SelectRandomObject()
    {
        float totalWeight = 0;

        // Calculate total weight
        for (int i = 0; i < weightedObjects.Count; i++)
        {
            totalWeight += weightedObjects[i].weight;
        }

        // Generate a random value between 0 and totalWeight
        float randomValue = Random.Range(0f, totalWeight);

        // Loop through the list of objects to find the selected one
        float cumulativeWeight = 0;
        for (int i = 0; i < weightedObjects.Count; i++)
        {
            cumulativeWeight += weightedObjects[i].weight;

            // If the random value falls within this object's weight, return it
            if (randomValue <= cumulativeWeight)
            {
                return weightedObjects[i].gameObject;
            }
        }

        // This should never happen, but just in case
        Debug.LogError("Failed to select a random object!");
        return null;
    }

    // Instantiate the selected object on a random point of this game object
    public void InstantiateRandomObjectOnRandomPoint()
    {
         selectedObject = SelectRandomObject();
        if (selectedObject != null)
        {
            Vector3 randomPoint = RandomPointOnGameObjectBounds(transform);
            Instantiate(selectedObject, randomPoint, Quaternion.identity);
        }
    }

    // Get a random point on the bounds of a game object
    private Vector3 RandomPointOnGameObjectBounds(Transform objTransform)
    {
        Renderer rend = objTransform.GetComponent<Renderer>();
        Bounds bounds = rend.bounds;
        Vector3 randomPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
        return randomPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(selectedObject);
        if (!hasStarted)
        {
            // Initial delay
            if (timer >= initialDelay)
            {
                hasStarted = true;
                InstantiateRandomObjectOnRandomPoint();
                //Debug.Log("Spawned");
                
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            // Random interval instantiation
            if (timer >= Random.Range(minInterval, maxInterval))
            {
                //Debug.Log("Spawned");
                InstantiateRandomObjectOnRandomPoint();
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
