using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPosAdj : MonoBehaviour
{
    public GameObject objToFollow;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = objToFollow.transform.position;
        gameObject.transform.rotation= objToFollow.transform.rotation;
    }
}
