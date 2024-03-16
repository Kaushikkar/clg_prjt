using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_detector : MonoBehaviour
{
    public bool isLeftAbility;
    public bool isRightAbility;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 playerRelativePosition = transform.InverseTransformPoint(other.transform.position);
            if(playerRelativePosition.x<0)
            {
                Debug.Log("Left");
                isLeftAbility = true;
                isRightAbility = false;
            }
            else if (playerRelativePosition.x > 0)
            {
                Debug.Log("Right");
                isRightAbility= true;
                isLeftAbility= false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
