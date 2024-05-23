using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Array of player prefabs
    public Transform[] spawnPoints; // Array of spawn points

    private List<Transform> availableSpawnPoints; // List of available spawn points

    private void Start()
    {
        // Initialize the list of available spawn points
        availableSpawnPoints = new List<Transform>(spawnPoints);

        if (availableSpawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points set in the PlayerSpawner.");
            return;
        }

        if (playerPrefabs.Length == 0)
        {
            Debug.LogError("No player prefabs set in the PlayerSpawner.");
            return;
        }

        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        // Select a random available spawn point
        int randomSpawnIndex = Random.Range(0, availableSpawnPoints.Count);
        Transform spawnPoint = availableSpawnPoints[randomSpawnIndex];

        // Select a random player prefab
        int randomPlayerIndex = Random.Range(0, playerPrefabs.Length);
        GameObject playerToSpawn = playerPrefabs[randomPlayerIndex];

        // Instantiate the player at the selected spawn point
        GameObject spawnedPlayer = PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, spawnPoint.rotation);

        // Remove the used spawn point from the list of available spawn points
        availableSpawnPoints.RemoveAt(randomSpawnIndex);
    }
}
