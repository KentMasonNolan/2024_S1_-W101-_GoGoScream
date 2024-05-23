using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CarGameManager : MonoBehaviourPunCallbacks
{
    public int index;
    public GameObject[] cars;
    private Vector3 startPos = new Vector3(37, 0, 160);

    // Start is called before the first frame update
    void Start()
    {
        // Ensure Photon Network is connected
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            Debug.LogError("Photon Network is not ready!");
            return; // Ensure no further Photon-dependent code runs
        }

        // Get carIndex from PlayerPrefs with a default value if not set

        index = PlayerPrefs.GetInt("carIndex", 0); // Default to 0 if carIndex isn't set

        // Check if the cars array is properly initialized and index is within bounds
        if (cars == null || cars.Length == 0)
        {
            Debug.LogError("Cars array is not initialized!");
            return;
        }
        if (index < 0 || index >= cars.Length)
        {
            Debug.LogError("Car index is out of bounds!");
            return;
        }

        // Instantiate the car for the network
        GameObject car = PhotonNetwork.Instantiate(cars[index].name, startPos, Quaternion.identity);
        car.AddComponent<OnlineCarControl>();
        if (car == null)
        {
            Debug.LogError("Failed to instantiate car!");
            return;
        }

        // Check if the local player owns this car
        PhotonView photonView = car.GetComponent<PhotonView>();
        if (photonView == null)
        {
            Debug.LogError("PhotonView component is missing on the car prefab!");
            return; // Stop execution if no PhotonView component found
        }

        if (photonView.IsMine)
        {
            car.name = "Player";
            car.tag = "Player";
/*            photonView.OwnershipTransfer = OwnershipOption.Takeover;*/

        }
    }

    public void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        // Check if the current instance is the master client
        if (PhotonNetwork.IsMasterClient)
        {
            ResetPlayers();
        }
    }

    void ResetPlayers()
    {
        // Destroy existing player objects
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            PhotonNetwork.Destroy(player);
        }

        // Instantiate a new car for each player
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            // Generate a unique spawn position for each player

            // Instantiate a car for the player
            GameObject car = PhotonNetwork.Instantiate(cars[index].name, startPos, Quaternion.identity);
            car.tag = "Player"; // Set the tag to "Player" for each car
            car.AddComponent<OnlineCarControl>();

            // Optionally, you can assign some identifier to the car to associate it with the player
            // For example, you could use player.UserId or player.NickName
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
