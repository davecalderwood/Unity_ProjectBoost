using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1200f;
    [SerializeField] float rotationThrust = 175f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem thrustParticle;
    Rigidbody rb;
    AudioSource audioSource;
    public bool inWindZone = false;
    public GameObject windZone;
    private float speedBoost; 
    // different than mainThrust; this is for the temporary boost multiplier
    private float boostTimer;
    private bool isBoosting;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        speedBoost = 1f;
        boostTimer = 0f;
        isBoosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindZone = true;

            Debug.Log("Player Entered WindArea");
        }

        if(other.gameObject.tag == "Boost")
        {
            isBoosting = true;
            speedBoost = 3f;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "windArea")
        {
            inWindZone = false;
            
            Debug.Log("Player Left WindArea");
        }
    }

    void FixedUpdate() 
    {
        if(inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        if(isBoosting)
        {
            boostTimer += Time.deltaTime;

            if(boostTimer >= 1)
            {
                speedBoost = 1f;
                boostTimer = 0f;
                isBoosting = false;
            }
        }
        rb.AddRelativeForce(Vector3.up * mainThrust * speedBoost * Time.deltaTime);

        // if (!audioSource.isPlaying)
        // {
        //     audioSource.PlayOneShot(mainEngine);
        // }

        SoundController.instance.ThrustingSound();
        
        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
        }
    }
    void StopThrusting()
    {
        audioSource.Stop();
        thrustParticle.Stop();
    }

    void ProcessRotation()
    {

        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
