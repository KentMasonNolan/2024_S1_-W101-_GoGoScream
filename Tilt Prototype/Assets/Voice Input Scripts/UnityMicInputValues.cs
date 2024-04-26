using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class UnityMicInputValues : MonoBehaviour
{
    AudioSource audioSource;
    public string selectedDevice; //Default Mic
    public static float[] samples = new float[128];//Block for audioSource.GetOutputData()
    public static float micVolume = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (Microphone.devices.Length > 0)
        {
            selectedDevice = Microphone.devices[0].ToString();
            audioSource.clip = Microphone.Start(selectedDevice, true, 1, AudioSettings.outputSampleRate);
            audioSource.loop = true;

            //While position of mic in recording is greater than 0, play the mic clip
            while (!(Microphone.GetPosition(selectedDevice) > 0))
            {
                audioSource.Play();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        getOutputData();
    }

    void getOutputData()
    {
        audioSource.GetOutputData(samples, 0);
        float vals = 0.0f;
        micVolume = 0.0f;

        for(int i = 0;i < 128; i++)
        {
            vals += Mathf.Abs(samples[i]);
        }

        vals /= 128.0f;
        micVolume = vals;
    }
}
