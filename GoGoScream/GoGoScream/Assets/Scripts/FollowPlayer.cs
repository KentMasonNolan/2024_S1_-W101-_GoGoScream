using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // Make sure to include this if using Photon

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset = new Vector3(0, 4, -8);

    void Start()
    {
        if (PhotonNetwork.IsConnected) // Check if using Photon
        {
            // Find the local player's GameObject

            /* player = GameObject.FindWithTag("Player"); // Ensure your player GameObject has the tag 'Player'*/
            player = GameObject.Find("Player");
            Debug.Log("Found with tag: " + (player != null ? player.name : "null"));

        }
        else
        {
            player = GameObject.Find("Player"); // Fallback if not connected to Photon
            Debug.Log("Found without tag: " + player);
        }

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player is instantiated before this script runs.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate desired position based on player's position and rotation
            Vector3 desiredPosition = player.transform.position + player.transform.TransformDirection(offset);

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

            // Update rotation to match player's rotation
            transform.rotation = player.transform.rotation;
        }
    }
}
