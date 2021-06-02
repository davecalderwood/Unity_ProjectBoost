using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoad = 1.5f;
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                CrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        // TODO add sound effects on crash
        // TODO add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayLoad);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void CrashSequence() 
    {
        // TODO add sound effects on crash
        // TODO add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayLoad);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }

}
