using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro support
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviour
{
    public TMP_InputField lobbyNameInputField; // Change to TMP_InputField

    // Start is called before the first frame update
    void Start()
    {

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }


        if (lobbyNameInputField == null)
        {
            Debug.LogError("TMP_InputField is not assigned in the inspector!");
        }
    }

    public void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        // Optionally, join the lobby here or enable the UI for the player to join/create a lobby
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JoinOrCreateLobby()
    {
        string lobbyName = lobbyNameInputField.text;

        if (!string.IsNullOrEmpty(lobbyName))
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4; // Set the max players for the room

            // Try joining the room by name
            PhotonNetwork.JoinOrCreateRoom(lobbyName, roomOptions, TypedLobby.Default);
        }
        else
        {
            Debug.LogError("Lobby Name is empty or invalid");
        }
    }

    public void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        // Handle successful join here, such as loading the multiplayer scene or enabling multiplayer UI
    }

    public void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room creation failed: " + message);
        // Handle room creation failure, such as prompting the user with an error message
    }

}
