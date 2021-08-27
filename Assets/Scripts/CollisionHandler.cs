using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoad = 1.5f;
    // [SerializeField] AudioClip success;
    // [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    AudioSource audioSource;
    ParticleSystem particleController;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();      
    }

    void Update() 
    {
        RespondToDebugKeys();
    }
    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                // Debug.Log("Friendly");
                break;
            case "Laser":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Boost":
                Debug.Log("Boost");
                break;
            case "Bouncy":
                BouncyObject();
                break;
            default:
                CrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;

        SoundController.instance.SuccessSound();
        
        successParticle.Play();

        GetComponent<Movement>().enabled = false;
        GetComponent<ShootLaser>().enabled = false;
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
        isTransitioning = true;

        SoundController.instance.CrashSound();

        crashParticle.Play();

        GetComponent<Movement>().enabled = false;
        GetComponent<ShootLaser>().enabled = false;
        Invoke("ReloadLevel", delayLoad);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }

    void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // Toggle collision
        }
    }

    void BouncyObject()
    {
        Debug.Log("Bouncy");
    }

}
