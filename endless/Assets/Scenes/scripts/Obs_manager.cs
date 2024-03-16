using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_manager : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    private int randomindex;
    public GameObject obsToSpawn;
    public GameObject Randomobs()
    {
        randomindex=Random.Range(0, obstacles.Count);
        obsToSpawn = obstacles[randomindex];
        return obsToSpawn;
    }
}
