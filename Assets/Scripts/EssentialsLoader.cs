using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    void Awake()
    {
        if(PauseMenu.instance == null)
        {
            Instantiate(PauseMenuScreen);
        }
    }

    void Update()
    {
        
    }
}
