using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarControl : MonoBehaviour
{
    private float carSpeed = 15.0f; //Car speed
    private Rigidbody carRigidbody;
    public float tilt;
    private float forwardInput;
    public Joystick joystick;
    public GameObject canvas;
   

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
        tilt = Input.acceleration.x * 100;
        //Vector3 movement = transform.forward * carSpeed * Time.deltaTime;
        //carRigidbody.MovePosition(carRigidbody.position + movement);

        forwardInput = joystick.Vertical * 2;
    //   transform.Translate(Vector3.forward * Time.deltaTime * forwardInput);//* carSpeed
        transform.Translate(Vector3.forward * Time.deltaTime * carSpeed * forwardInput);
        //Rotate the car left and right based on tilt
        Quaternion targetRotation = Quaternion.Euler(0, tilt, 0); //Speed of rotation
        carRigidbody.MoveRotation(Quaternion.Lerp(carRigidbody.rotation, targetRotation, 1 * Time.fixedDeltaTime));
    }

}
