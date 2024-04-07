using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cont_obsSpawner : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 updatedPosition;
    SpawnPointManager SpawnPointManager;
    public bool changed;
    void Start()
    {
        initialPosition = gameObject.transform.position;
        SpawnPointManager=GetComponent<SpawnPointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        updatedPosition= gameObject.transform.position;
        if(updatedPosition!=initialPosition)
        {
            changed= true;
            //Debug.Log("Road moved"+gameObject.name);
            SpawnPointManager.SpawnObjectsAtRandomPoints();
            initialPosition = updatedPosition;
        }
        else
        {
            changed= false;
        }
    }
}
