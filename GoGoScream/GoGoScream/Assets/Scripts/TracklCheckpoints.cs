using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracklCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;
    private int lapCount;
    private int totalLaps;
    private bool raceStart;

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject hud;

    void Start() {
        canvas1 = GameObject.Find("FinishUI");
        canvas2 = GameObject.Find("TouchUI");
        canvas3 = GameObject.Find("GameUI");
        hud = GameObject.Find("hud");
        canvas1.SetActive(false);
    }

    private void Awake() {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform) {
        CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
        checkpointSingle.SetTrackCheckpoints(this);

        checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndex = 0;
        lapCount = 0;
        totalLaps = 1;
        raceStart = false;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle) {
        int checkpointIndex = checkpointSingleList.IndexOf(checkpointSingle);

        if (checkpointIndex == nextCheckpointSingleIndex) {
            Debug.Log("Correct checkpoint");
            if (nextCheckpointSingleIndex == 0) {
                if (raceStart) {
                    lapCount++;
                    Debug.Log("Lap Count: " + lapCount);

                    if (lapCount == totalLaps) {
                        StartCoroutine(EndRace());
                    }
                }
            } else {
                raceStart = true;
            }
            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
        } else {
            Debug.Log("Incorrect checkpoint");
        }
    }

    IEnumerator EndRace() {
        Debug.Log("Race Finished");
        yield return new WaitForSeconds(1);
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        hud.SetActive(false);
        Time.timeScale = 0;
        raceStart = false;
    }
}
