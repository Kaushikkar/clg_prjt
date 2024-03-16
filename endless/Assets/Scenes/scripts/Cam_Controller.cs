using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Adjust the offset as needed

    public float rotationSpeed = 5f; // Rotation speed of the camera
    public float smoothTime = 0.3f; // Smooth time for damping
    public float lookAtIntensity = 1f; // Intensity of the look-at function

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned to the camera!");
            return;
        }

        // Calculate the desired position with offset
        Vector3 desiredPosition = player.position + offset;

        // Use SmoothDamp to smoothly move the camera towards the desired position
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

        // Rotate the camera to look at the player's position with adjustable intensity
        Quaternion desiredRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed * lookAtIntensity);
    }
}
