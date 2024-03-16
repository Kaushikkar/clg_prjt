using UnityEngine;

public class model_fix : MonoBehaviour
{
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    private Transform parentTransform;
    private Transform childTransform;

    void Start()
    {
        // Get references to parent and child transforms
        parentTransform = transform.parent;
        childTransform = transform;
    }

    void Update()
    {
        // Copy parent's position and rotation to the child with offsets
        childTransform.position = parentTransform.position + positionOffset;
        //childTransform.rotation = parentTransform.rotation * Quaternion.Euler(rotationOffset);
    }
}
