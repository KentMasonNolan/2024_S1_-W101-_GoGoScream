using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAudioDevices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
           Debug.Log("Found audio input device: " + device);
        }

        if (Microphone.devices.Length == 0)
        {
           Debug.Log("No audio input devices detected.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
