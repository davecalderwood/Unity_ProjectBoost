using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
    [SerializeField] public float cannonStrength;
    [SerializeField] public Vector3 cannonDirection;
    private void Update() 
    {
        transform.Translate(cannonDirection * cannonStrength * Time.deltaTime);
        
        Object.Destroy(gameObject, 5.0f);
    }
}
