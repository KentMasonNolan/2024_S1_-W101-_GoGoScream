using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class CarControl : MonoBehaviour
{
    private Rigidbody carRigidbody;
    public float tilt;
    private float forwardInput;
    public Joystick joystick;
    public GameObject joyStickCanvas;

    // public float turnSpeed;
    public float baseSpeed = 0f; // Base speed is 0 to stop movement when no sound detected
    public float speedMultiplier = 500.0f; //Adjust speed based on how loud you need to speak to move
    public float audioThreshold = 0.01f; //Threshold for detecting audio, adjust based on testing
    public float horizontalInput;
    public float moveForwardInput;
    private float speedTimer = 3.0f;
    private float powerupMultiplier = 550.0f;
    // public float speed;

    public GameObject speedArrow;
    public Vector3 arrowRotation = new Vector3(0, 0, 71);
    private float minAngle = 75.0f;
    private float maxAngle = -75.0f;


    public Toggle tiltToggle;
    public Toggle joystickToggle;
   
   private float speed = 30.0f;
   private float turnSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>(); 
        joyStickCanvas = GameObject.Find("TouchUI");
        joystick = joyStickCanvas.transform.Find("Joystick").gameObject.GetComponent<Joystick>();

        speedArrow = GameObject.Find("arrow");
    }

    void Update()
    {
        // tiltToggle = GameObject.Find("toggle tilt").gameObject.GetComponent<Toggle>();
        // joystickToggle = GameObject.Find("toggle joystick").gameObject.GetComponent<Toggle>();

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // tilt = Input.acceleration.x * 90;
        // Vector3 movement = transform.forward * carSpeed * Time.deltaTime;
        // carRigidbody.MovePosition(carRigidbody.position + movement);


        // if(joystickToggle.isOn == true)
        // {
        
        // joyStickCanvas.SetActive(true);
        // //Joystick control
        // forwardInput = joystick.Vertical * 2;
        // transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * forwardInput);

        // }

        // if(joystickToggle.isOn != true)
        // {
        //     joyStickCanvas.SetActive(false);
        // }

        // if(tiltToggle.isOn == true)
        // {
        //     Debug.Log("tilt on");
        // //Rotate the car left and right based on tilt
        // Quaternion targetRotation = Quaternion.Euler(0, tilt, 0); //Speed of rotation
        // carRigidbody.MoveRotation(Quaternion.Lerp(carRigidbody.rotation, targetRotation, 1 * Time.fixedDeltaTime));
        // }

        

        
      
    }

    void LateUpdate()
    { 
    
        // horizontalInput = Input.GetAxis("Horizontal");
        // moveForwardInput = Input.GetAxis("Vertical");

        // //Adjust speed based on audio vol, only move if above threshold
        // float currentVolume = UnityMicInputValues.micVolume;
        // speed = (currentVolume > audioThreshold) ? baseSpeed + (currentVolume * speedMultiplier) : 0;

        // //Apply the calculated speed to move the car forward
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        // if(speed >0)
        // {
        // speedArrow.transform.eulerAngles = new Vector3(0, 0, GetSpeedRotation()*(speed/100));
        // }

        // else{
        //       speedArrow.transform.eulerAngles = new Vector3(0, 0, minAngle);
        // }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Powerup")) {
            speedMultiplier = powerupMultiplier;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(speedTimer);
        speedMultiplier = 500.0f;
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = minAngle - maxAngle;

        return totalAngleSize;
    }



}