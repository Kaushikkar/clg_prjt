using UnityEngine;

public class P_ability : MonoBehaviour
{
    public P_collectibles ability;
    public GameObject childObject; // Reference to the child object you want to disable

    // Update is called once per frame
    void Update()
    {
        if (!ability.notVulnerable) // If notVulnerable is false
        {
            // Disable the child object
            if (childObject != null)
            {
                childObject.SetActive(false);
            }
        }
        else
        {
            if (childObject != null)
            {
                childObject.SetActive(true);
            }
        }
    }
}
