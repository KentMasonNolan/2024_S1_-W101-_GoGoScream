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
             Time.timeScale = 0;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
      
        }
    }

    public void unpauseGame()
    {
              Time.timeScale = 1.0f;
        if (pauseMenu != null)
        {
       
            pauseMenu.SetActive(false);
        }
    }
}
