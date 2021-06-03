using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanWind : MonoBehaviour
{
    [SerializeField] float fanRotationX = 0;
    [SerializeField] float fanRotationY = 0;
    [SerializeField] float fanRotationZ = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(fanRotationX, fanRotationY, fanRotationZ);
    }
}
