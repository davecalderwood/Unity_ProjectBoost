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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "windArea")
        {
            inWindZone = false;
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
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
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
