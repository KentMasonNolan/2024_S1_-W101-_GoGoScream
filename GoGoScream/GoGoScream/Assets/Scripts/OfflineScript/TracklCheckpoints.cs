using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracklCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    public int nextCheckpointSingleIndex;
    private int lapCount;
    public int totalLaps;
    private bool raceStart;

    public GameObject FinishUI;
    public GameObject TouchUI;
    public GameObject GameUI;
    public GameObject hud;

    public void Start() {
        if (FinishUI == null) FinishUI = GameObject.Find("FinishUI");
        if (TouchUI == null) TouchUI = GameObject.Find("TouchUI");
        if (GameUI == null) GameUI = GameObject.Find("GameUI");
        if (hud == null) hud = GameObject.Find("hud");

        if (FinishUI != null) FinishUI.SetActive(false);
        if (TouchUI == null) Debug.LogError("TouchUI not found");
        if (GameUI == null) Debug.LogError("GameUI not found");
        if (hud == null) Debug.LogError("hud not found");
    }

    public void Awake() {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        if (checkpointsTransform != null)
        {
            foreach (Transform checkpointSingleTransform in checkpointsTransform) {
                CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
                if (checkpointSingle != null)
                {
                    checkpointSingle.SetTrackCheckpoints(this);
                    checkpointSingleList.Add(checkpointSingle);
                }
            }
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
        Time.timeScale = 0;

        if (FinishUI != null) {
            FinishUI.SetActive(true);
            Debug.Log("FinishUI found");
        } else {
            Debug.LogError("FinishUI not found");
        }
        if (TouchUI != null) TouchUI.SetActive(false);
        if (GameUI != null) GameUI.SetActive(false);
        if (hud != null) hud.SetActive(false);
        raceStart = false;
    }

    public int GetLapCount() {
        return lapCount;
    }

    public bool IsRaceFinished() {
        return !raceStart;
    }
}
