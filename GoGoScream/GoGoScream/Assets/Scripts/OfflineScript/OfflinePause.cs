using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflinePause : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the pause menu

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame()
    {
       
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void unpauseGame()
    {
        if (pauseMenu != null)
        {
               Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
    }
}
