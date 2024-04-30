using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // public float turnSpeed;
    // public float baseSpeed = 0f; // Base speed is 0 to stop movement when no sound detected
    // public float speedMultiplier = 10.0f; //Adjust speed based on how loud you need to speak to move
    // public float audioThreshold = 0.01f; //Threshold for detecting audio, adjust based on testing
    // public float horizontalInput;
    // public float forwardInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // forwardInput = Input.GetAxis("Vertical");

        // //Adjust speed based on audio vol, only move if above threshold
        // float currentVolume = UnityMicInputValues.micVolume;
        // float speed = (currentVolume > audioThreshold) ? baseSpeed +
        //     (currentVolume * speedMultiplier) : 0;

        
        // //Apply the calculated speed to move the car forward
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
