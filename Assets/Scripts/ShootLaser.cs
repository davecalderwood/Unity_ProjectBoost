using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    private bool fireLaser = false;
    [SerializeField] private Transform laserPrefab;
    [SerializeField] Transform Spawnpoint;
    [SerializeField] float fireSpeed;
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.W)&& !fireLaser)   
        {
            Instantiate(laserPrefab, Spawnpoint.position, transform.rotation);
            fireLaser = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))   
        {
            fireLaser = false;
        }
    }
}
