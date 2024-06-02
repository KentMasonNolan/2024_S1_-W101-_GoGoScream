using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FinishLineTest
{
    private GameObject gameObject;
    private TracklCheckpoints trackCheckpoints;
    private List<CheckpointSingle> checkpointSingleList;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        trackCheckpoints = gameObject.AddComponent<TracklCheckpoints>();

        // Create mock GameObjects for FinishUI, TouchUI, GameUI, hud
        trackCheckpoints.FinishUI = new GameObject("FinishUI");
        trackCheckpoints.TouchUI = new GameObject("TouchUI");
        trackCheckpoints.GameUI = new GameObject("GameUI");
        trackCheckpoints.hud = new GameObject("hud");

        trackCheckpoints.FinishUI.SetActive(false);

        // Create a parent GameObject for checkpoints
        GameObject checkpointsParent = new GameObject("Checkpoints");
        checkpointsParent.transform.SetParent(gameObject.transform);

        // Setup Checkpoints
        checkpointSingleList = new List<CheckpointSingle>();
        for (int i = 0; i < 4; i++)
        {
            GameObject checkpointGameObject = new GameObject("Checkpoint" + i);
            checkpointGameObject.transform.SetParent(checkpointsParent.transform);
            CheckpointSingle checkpointSingle = checkpointGameObject.AddComponent<CheckpointSingle>();
            checkpointSingleList.Add(checkpointSingle);
        }

        // Manually call Awake to initialize after setting up checkpoints
        trackCheckpoints.Awake();
        trackCheckpoints.Start();
    }

    [Test]
    public void CorrectCheckpoints()
    {
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[0]);
        Assert.AreEqual(1, trackCheckpoints.nextCheckpointSingleIndex);

        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[1]);
        Assert.AreEqual(2, trackCheckpoints.nextCheckpointSingleIndex);

        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[2]);
        Assert.AreEqual(3, trackCheckpoints.nextCheckpointSingleIndex);

        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[3]);
        Assert.AreEqual(0, trackCheckpoints.nextCheckpointSingleIndex);
    }

    [UnityTest]
    public IEnumerator FinishLineShowsFinishUI()
    {
        trackCheckpoints.totalLaps = 1;
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[0]); // Start the race
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[1]);
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[2]);
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[3]);
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[0]); // Complete the lap

        yield return new WaitForSeconds(1);

        Assert.IsTrue(trackCheckpoints.FinishUI.activeSelf, "FinishUI should be active.");
    }

    [UnityTest]
    public IEnumerator FinishLineStopsTime()
    {
        trackCheckpoints.totalLaps = 1;
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[0]); // Start the race
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[1]);
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[2]);
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[3]);
        trackCheckpoints.PlayerThroughCheckpoint(checkpointSingleList[0]); // Complete the lap

        yield return new WaitForSeconds(1);

        Assert.AreEqual(0, Time.timeScale, "Time.timeScale should be 0.");
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }
}