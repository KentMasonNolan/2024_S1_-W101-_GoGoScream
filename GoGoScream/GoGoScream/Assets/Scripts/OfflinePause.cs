using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflinePause : MonoBehaviour
{
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
    }

   public void unpauseGame()
    {
        Time.timeScale = 1.0f;
    }
}