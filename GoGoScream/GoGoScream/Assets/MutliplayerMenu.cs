using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MutliplayerMenu : MonoBehaviour
{

    public GameObject lobbyRoom;
    public GameObject joinRoom;
    public GameObject hostRoom;
    public GameObject multiplayerRoom;


    public void OnHostClick()
    {
        multiplayerRoom.SetActive(false);
        hostRoom.SetActive(true);

    }

}
