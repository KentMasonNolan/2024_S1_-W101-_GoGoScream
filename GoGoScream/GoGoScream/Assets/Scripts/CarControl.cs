using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarControl : MonoBehaviour
{
    private Rigidbody carRigidbody;
    public float tilt;
    private float forwardInput;
    public Joystick joystick;
    public GameObject canvas;

    public float turnSpeed;
    public float baseSpeed = 0f; // Base speed is 0 to stop movement when no sound detected
    public float speedMultiplier = 500.0f; //Adjust speed based on how loud you need to speak to move
    public float audioThreshold = 0.01f; //Threshold for detecting audio, adjust based on testing
    public float horizontalInput;
    public float moveForwardInput;


    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>(); 
        canvas = GameObject.Find("TouchUI");
        joystick = canvas.transform.Find("Joystick").gameObject.GetComponent<Joystick>();
        canvas.SetActive(true);
        

    }

    void FixedUpdate()
    {
        //Move car forward consistently
        tilt = Input.acceleration.x * 90;
        //Vector3 movement = transform.forward * carSpeed * Time.deltaTime;
        //carRigidbody.MovePosition(carRigidbody.position + movement);

        //Joystick control
        forwardInput = joystick.Vertical * 2;
        transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * forwardInput);

        //Rotate the car left and right based on tilt
        Quaternion targetRotation = Quaternion.Euler(0, tilt, 0); //Speed of rotation
        carRigidbody.MoveRotation(Quaternion.Lerp(carRigidbody.rotation, targetRotation, 1 * Time.fixedDeltaTime));
    }

    void LateUpdate()
    { 
        horizontalInput = Input.GetAxis("Horizontal");
        moveForwardInput = Input.GetAxis("Vertical");

        //Adjust speed based on audio vol, only move if above threshold
        float currentVolume = UnityMicInputValues.micVolume;
        float speed = (currentVolume > audioThreshold) ? baseSpeed + (currentVolume * speedMultiplier) : 0;

        //Apply the calculated speed to move the car forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

}