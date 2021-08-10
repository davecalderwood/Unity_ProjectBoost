using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Laser")
        {
            Debug.Log("Laser hit Trigger");
        }
    }
}
