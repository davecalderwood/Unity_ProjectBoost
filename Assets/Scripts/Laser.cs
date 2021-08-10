using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] public float laserStrength;
    [SerializeField] public Vector3 laserDirection;
    private void Update() 
    {
        transform.Translate(laserDirection * laserStrength * Time.deltaTime);
        
        Object.Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Trigger")
        {
            Debug.Log("Laser hit Trigger");
        }
    }
}
