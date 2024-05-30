using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineFollowPlayer : MonoBehaviour
{
 
    private GameObject player;
    private Vector3 offset = new Vector3(0, 4, -8);


    // Start is called before the first frame update
  
    void Start()
    {

        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
          player = GameObject.Find("Player");
        // Calculate desired position based on player's position and rotation
        Vector3 desiredPosition = player.transform.position + player.transform.TransformDirection(offset);

        // Smoothly move the camera towards the desired position
       transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

        // Update rotation to match player's rotation
        transform.rotation = player.transform.rotation;
            
       // transform.position = player.transform.position + offset;
    }
}
