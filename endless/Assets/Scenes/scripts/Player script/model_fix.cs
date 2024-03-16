using UnityEngine;

public class ModelFix : MonoBehaviour
{
    public GameObject objToFollow;
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;

    void Update()
    {
        if (objToFollow != null)
        {
            
            transform.position = objToFollow.transform.position + offsetPosition;
            transform.rotation = objToFollow.transform.rotation * Quaternion.Euler(offsetRotation);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
