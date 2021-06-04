using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCannonBall : MonoBehaviour
{
    public GameObject CannonBall;
    public Transform Spawnpoint;
    public float firePower;

    public bool inCannonZone = false;
    public GameObject cannonZone;
    float cannonBallSpeed = 5f;
    bool isCreated;
    
    void OnTriggerEnter(Collider other) 
    {

        if(other.gameObject.tag == "Player")
        {
            cannonZone = other.gameObject;
            inCannonZone = true;
            Debug.Log("Player entered Cannon area");
        }
            if(!isCreated)
            {
                isCreated = true;
                Instantiate(CannonBall, Spawnpoint.position, Spawnpoint.rotation);
                transform.position += transform.forward * Time.deltaTime * cannonBallSpeed;
            }
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            inCannonZone = false;
            Debug.Log("Player left Cannon area");
        }
    }

    private void FixedUpdate() 
    {
        if(inCannonZone)
        {
            // rb.AddForce(cannonZone.GetComponent<CannonShot>().cannonDirection * cannonZone.GetComponent<CannonShot>().cannonStrength);
            if(!isCreated)
            {
                isCreated = true;
                Instantiate(CannonBall, Spawnpoint.position, Spawnpoint.rotation);
                transform.position += transform.forward * Time.deltaTime * cannonBallSpeed;
            }
        }
    }
}
