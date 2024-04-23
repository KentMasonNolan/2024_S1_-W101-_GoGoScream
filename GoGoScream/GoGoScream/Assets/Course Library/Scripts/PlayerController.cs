using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float speed = 30.0f;
   // private float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;
    public float tilt;
    public Joystick joystick;

    public Rigidbody carRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // horizontalInput = joystick.Horizontal;
        forwardInput = joystick.Vertical;
        tilt = Input.acceleration.x * 90;

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //     transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);


//Steering
        Quaternion targetRotation = Quaternion.Euler(0, tilt, 0); //Speed of rotation
        carRigidbody.MoveRotation(Quaternion.Lerp(carRigidbody.rotation, targetRotation, 1 * Time.fixedDeltaTime));
        //everything below is from tutorial - keyboard input
        /*
        //Get input 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward/backwards depending on user input
       // transform.Translate(0, 0, 1);
       transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

       //Move the vehicle left/right depending on user input
      // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
      transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

      */
    }
}
