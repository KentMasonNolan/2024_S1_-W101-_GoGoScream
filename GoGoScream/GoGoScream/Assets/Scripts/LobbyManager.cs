using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro support
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField lobbyNameInputField; // Change to TMP_InputField
    public TMP_InputField joinLobbyNameInputField; // Change to TMP_InputField
    public string playerPrefabName;
    public TMP_InputField nickname;
    public TMP_InputField JoinNickName;
    private string lobbyName;
    private string joinLobbyName;

    public List<playerItem> playerItemsList = new List<playerItem>();
    public playerItem playerItemPrefab;
    public Transform playerItemParent;

    public GameObject playButton;

    private void Update()
    {
        playButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnConnectedToMaster()
    {

        PhotonNetwork.AutomaticallySyncScene = true;

        if (!string.IsNullOrEmpty(lobbyName))
        {
            PhotonNetwork.CreateRoom(lobbyName);
        }
        else if (!string.IsNullOrEmpty(joinLobbyName))
        {
            PhotonNetwork.JoinRoom(joinLobbyName);
        }
    }

    public void OnHostConnect()
    {
        if (lobbyNameInputField != null && nickname != null)
        {
            lobbyName = lobbyNameInputField.text;
            PhotonNetwork.NickName = nickname.text;
            
            PhotonNetwork.ConnectUsingSettings(); // In Photon, this calls OnConnectedToMaster(). This ensures the host is the "master"
        }
        else
        {
            Debug.LogWarning("LobbyNameInputField or Nickname is not assigned.");
        }
    }

    public void JoinLobby()
    {
        if (joinLobbyNameInputField != null && nickname != null)
        {
            joinLobbyName = joinLobbyNameInputField.text;
            PhotonNetwork.NickName = JoinNickName.text;

            if (!string.IsNullOrEmpty(joinLobbyName))
            {
                if (PhotonNetwork.IsConnected)
                {
                    PhotonNetwork.JoinRoom(joinLobbyName);
                }
                else
                {
                    PhotonNetwork.ConnectUsingSettings();
                }
            }
            else
            {
                Debug.LogError("Join Lobby Name is empty or invalid");
            }
        }
        else
        {
            Debug.LogWarning("JoinLobbyNameInputField or Nickname is not assigned.");
        }
    }

    public void UpdatePlayerList()
    {

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            print(player.NickName);
        }

        foreach (playerItem item in playerItemsList)
        {
            Debug.Log($"Destroying player item: {item.gameObject.name}"); 
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            playerItem newplayerItem = Instantiate(playerItemPrefab, playerItemParent);
            playerItemsList.Add(newplayerItem);
            if (newplayerItem != null)
            {
                newplayerItem.SetPlayerInfo(player.Value); // Correctly access the Value property
                playerItemsList.Add(newplayerItem);
            }
            else
            {
                Debug.LogError("PlayerItem prefab is null!");
            }
        }
    }

    public void OnClickPlayButton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Track 1");
        }
        else
        {
            Debug.LogWarning("Only the master client can start the game.");
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        UpdatePlayerList();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room creation failed: " + message);
        // Handle room creation failure, such as prompting the user with an error message
    }
}
