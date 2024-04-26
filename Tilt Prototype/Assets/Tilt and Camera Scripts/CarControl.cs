using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarControl : MonoBehaviour
{
    //public float carSpeed = 15f; //Car speed
    private Rigidbody carRigidbody;
    public float tilt;
    private float forwardInput;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Move car forward consistently
        tilt = Input.acceleration.x * 90;
        //Vector3 movement = transform.forward * carSpeed * Time.deltaTime;
        //carRigidbody.MovePosition(carRigidbody.position + movement);

        forwardInput = joystick.Vertical;
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput);//* carSpeed

        //Rotate the car left and right based on tilt
        Quaternion targetRotation = Quaternion.Euler(0, tilt, 0); //Speed of rotation
        carRigidbody.MoveRotation(Quaternion.Lerp(carRigidbody.rotation, targetRotation, 1 * Time.fixedDeltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
