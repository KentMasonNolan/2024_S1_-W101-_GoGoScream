using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TracklCheckpoints trackCheckpoints;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerController>(out PlayerController playercontroller)) {
            trackCheckpoints.PlayerThroughCheckpoint(this);
        }
    }

    public void SetTrackCheckpoints(TracklCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }
}
