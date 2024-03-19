using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_wall : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private void Update()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z)+offset;
    }
}
