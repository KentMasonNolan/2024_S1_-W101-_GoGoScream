using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, transform, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag ("Powerup").Length == 0) {
            StartCoroutine(PowerupSpawnRoutine());
        }
    }

    IEnumerator PowerupSpawnRoutine() {
        yield return new WaitForSeconds(2);
        Instantiate(powerupPrefab, transform, true);
    }
}
