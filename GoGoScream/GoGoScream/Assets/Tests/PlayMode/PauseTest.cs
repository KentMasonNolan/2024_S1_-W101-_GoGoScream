using UnityEngine;
using NUnit.Framework;

public class OfflinePauseTest
{
    private GameObject gameObject;
    private OfflinePause offlinePause;
    private GameObject pauseMenu;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        offlinePause = gameObject.AddComponent<OfflinePause>();

        pauseMenu = new GameObject();
        pauseMenu.SetActive(false); // Ensure it starts inactive
        offlinePause.pauseMenu = pauseMenu;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(pauseMenu);
        Object.DestroyImmediate(gameObject);
    }


    [Test]
    public void pauseMenuActive()
    {
        // Act
        offlinePause.pauseGame();

        // Assert
        Assert.IsTrue(pauseMenu.activeSelf, "pause menu is activate when pause button clicked");
    }

     [Test]
    public void pauseMenuInactive()
    {
        // Act
        offlinePause.pauseGame(); // First pause the game to set it active
        offlinePause.unpauseGame();

        // Assert
        Assert.IsFalse(pauseMenu.activeSelf, "pause menu is inactive when return to game is clicked");
    }


    [Test]
    public void gamePaused()
    {
        // Act
        offlinePause.pauseGame();

        // Assert
        Assert.AreEqual(0, Time.timeScale);
    }

    [Test]
    public void gameUnpaused()
    {
        // Act
        offlinePause.unpauseGame();

        // Assert
        Assert.AreEqual(1.0f, Time.timeScale);
    }



   
}
