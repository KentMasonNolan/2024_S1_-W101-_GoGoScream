using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    public GameObject powerupPrefab;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start() {
        foreach (Transform spawnPoint in spawnPoints)
        {
            StartCoroutine(PowerupSpawnRoutine(spawnPoint));
        }
    }

    IEnumerator PowerupSpawnRoutine(Transform spawnPoint) {
        while (true)
        {
            if (spawnPoint.childCount == 0) {
                GameObject powerup = Instantiate(powerupPrefab, spawnPoint.position, spawnPoint.rotation);
                powerup.transform.SetParent(spawnPoint);
            }
            yield return new WaitForSeconds(2);
        }
    }
}
