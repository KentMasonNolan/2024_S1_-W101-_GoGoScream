using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CarGameManager : MonoBehaviour
{

    public int index;
    public GameObject[] cars;
    private Vector3 startPos = new Vector3(37, 0, 160);

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            index = PlayerPrefs.GetInt("carIndex");

            // Instantiate the car for the network
            GameObject car = PhotonNetwork.Instantiate(cars[index].name, startPos, Quaternion.identity);

            // Check if the local player owns this car
            if (car.GetComponent<PhotonView>().IsMine)
            {
                car.AddComponent<PlayerController>();
                car.name = "Player";
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
