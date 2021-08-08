using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : MonoBehaviour
{
    public GameObject TrapZone;
    public GameObject objectToMove;
    public Vector3 moveDirection;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Thrust Trap...");
            objectToMove.transform.position += moveDirection;
        }
    }
}
