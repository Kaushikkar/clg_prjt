using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_filter : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Obstacles")
        {
            //Debug.Log("Obstacles collided");
            Destroy(collision.gameObject);
        }
    }
}
