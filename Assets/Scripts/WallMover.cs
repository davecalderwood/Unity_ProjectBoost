using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
 public float speed;
 [SerializeField] Vector3 wallMoveDirection;
    void Update() 
    {
        transform.Translate(wallMoveDirection * Time.deltaTime * speed);
    }
}
