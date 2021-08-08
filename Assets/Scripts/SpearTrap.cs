using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : MonoBehaviour
{
    public GameObject trapZone;
    public bool inTrapZone = false;
    public GameObject objectToMove;
    public Vector3 moveDirection;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            trapZone = other.gameObject;
            inTrapZone = true;
            
            objectToMove.transform.position += moveDirection;
        }
    }
}
