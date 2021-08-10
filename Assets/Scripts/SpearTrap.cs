using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : MonoBehaviour
{
    [SerializeField] GameObject spearTrap;
    // [SerializeField] Vector3 movePosition;
    [SerializeField] float speed;
    [SerializeField] float distance;
    bool hasMoved = false;
    private void OnTriggerEnter(Collider other) 
    {
        // spearTrap.transform.position = Vector3.Lerp(spearTrap.transform.position, movePosition, Time.deltaTime * speed);

        if(!hasMoved)
        {
            spearTrap.transform.position += spearTrap.transform.up * distance * speed;
            hasMoved = true;
        }
    }
}
