using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] public float laserStrength;
    [SerializeField] public Vector3 laserDirection;
    [SerializeField] public string[] objectToDestroy;
    private void Update() 
    {
        transform.Translate(laserDirection * laserStrength * Time.deltaTime);
        
        Object.Destroy(gameObject, 3.0f);
    }
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name);
        if (other.gameObject.tag == "Trigger")
        {
            Destroy(gameObject);
            Destroy(GameObject.Find("Gate"));
        }
    }
}
