using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{

    [SerializeField] private InputAction thrust, rotation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotStrength;
    [SerializeField] private AudioSource thrustAudio;

    public float thrustForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        thrust.Enable(); 
        rotation.Enable();
    }

    private void OnDisable()
    {
        thrust.Disable(); 
        rotation.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();

        
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {

            rb.AddRelativeForce(Vector3.up * thrustForce * Time.fixedDeltaTime);
            thrustAudio.enabled = true;
        }
        else
        {
            thrustAudio.enabled = false;
        }
    }

    private void ProcessRotation()
    {
       float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            ApplyRotation(-rotStrength);
        }
        if (rotationInput > 0)
        {
            ApplyRotation(rotStrength);
        }
    }

    private void ApplyRotation(float rotationStrength)
    {
        transform.Rotate(Vector3.forward * rotationStrength * Time.deltaTime);
    }
}
