using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_filer : MonoBehaviour
{



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "Obstacles")
        {
            //Debug.Log("Collided");
            Destroy(collision.gameObject);
        }
    }



}
