using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_filer : MonoBehaviour
{


    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("Collided");
            Destroy(collision.gameObject);
        }
    }
}
