using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBTwo : MonoBehaviour
{
    public GameObject CannonBall;
    public Transform Spawnpoint;
    public float spawnTime = 3f;

    void Start () {
        InvokeRepeating("SpawnBall", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update () {
    }    
    void SpawnBall()
    {
        var newBall = GameObject.Instantiate(CannonBall, Spawnpoint.position, Spawnpoint.rotation);
    }
}
