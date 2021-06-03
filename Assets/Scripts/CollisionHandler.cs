using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoad = 1.5f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    AudioSource audioSource;
    ParticleSystem particleController;

    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();      
    }
    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) { return; }

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
        isTransitioning = true;

        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticle.Play();

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
        isTransitioning = true;

        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticle.Play();

        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayLoad);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }

}