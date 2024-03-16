using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public RoadSpawner sp;
    
    public void SpawnTriggerEnter()
    {

        sp.MoveRoad();
        
    }
}