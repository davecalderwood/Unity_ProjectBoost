using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    public float currentFuel = 100f;
    public Text fuelDisplay;

    private void Start() 
    {
    }
    private void Update() 
    {
        fuelDisplay.text = "Fuel: " + currentFuel;
    }
}
