using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerController : MonoBehaviourPun
{
    private float speed = 50.0f;
    private float turnSpeed = 100.0f;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody rb;
    PhotonView view;

    public void Initialize()
    {
        // Initialize any necessary variables or states
        speed = 50.0f;  // Default speed, if not set elsewhere
        turnSpeed = 100.0f;  // Default turn speed

        // Ensure any required components are added and configured
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)  // Check if Rigidbody is already attached
        {
            rb = gameObject.AddComponent<Rigidbody>();  // Add Rigidbody if not already attached
        }
        rb.isKinematic = false;  // Make sure Rigidbody is not kinematic
        rb.useGravity = true;  // Ensure gravity is applied if needed

        // Set up other necessary components or initial states
        // For example, setting initial positions or rotations, if needed

        Debug.Log("PlayerController initialized.");
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Player unput for car
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        Debug.Log("Horizontal Input: " + horizontalInput);
        Debug.Log("Forward Input: " + forwardInput);

        if (horizontalInput != 0 || forwardInput != 0)
        {
            Debug.Log("Input received: Horizontal = " + horizontalInput + ", Vertical = " + forwardInput);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

    }
}

