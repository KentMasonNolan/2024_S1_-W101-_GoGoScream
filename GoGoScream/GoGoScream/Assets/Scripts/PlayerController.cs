using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30.0f;
    private float turnSpeed = 100.0f;
    private float horizontalInput;
    private float forwardInput;

    private float powerupSpeed = 40.0f;
    private float powerdownSpeed = 20.0f;
    private float speedTimer = 5;
    // public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         //Player unput for car
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("powerup")) {
            speed = powerupSpeed;
            Destroy(other.gameObject);
            // powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(speedTimer);
        speed = powerdownSpeed;
        // powerupIndicator.SetActive(false);
    }
}
