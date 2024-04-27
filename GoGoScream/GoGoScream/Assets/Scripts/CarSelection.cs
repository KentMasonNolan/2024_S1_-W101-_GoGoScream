using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;
    public Button next;
    public Button prev;

    public TrackSelection trackSelection;

    int index;
    // Start is called before the first frame update
    void Start()
    {

        index = PlayerPrefs.GetInt("carIndex");
        Debug.Log(index);
        if (index >= 0 && index < cars.Length)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[index].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index > cars.Length - 2)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;

        }

        if (index <= 0)
        {
            prev.interactable = false;
        }
        else
        {
            prev.interactable = true;
        }
    }

    public void Next()
    {

        if (index < cars.Length - 1)
        {
            index++;
            Debug.Log(index);

            for (int i = 0; i < cars.Length; i++)
            {
                if (i != index)
                {
                    cars[i].SetActive(false);
                }

                cars[index].SetActive(true);
                PlayerPrefs.SetInt("carIndex", index);
                PlayerPrefs.Save();

            }

        }
        else
        {
            return;
        }


    }

    public void Prev()
    {
        if (index > 0)
        {
            index--;

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[index].SetActive(true);

                PlayerPrefs.SetInt("carIndex", index);
                PlayerPrefs.Save();
            }
        }

        else
        {
            return;
        }


    }

    public void Race()
    {
        string trackName = ""; 
        string selectedTrack = trackSelection.getTrack(); // Get the selected track object name

        // Map the object names to the corresponding scene names
        if (selectedTrack == "Select1")
        {
            trackName = "Track 1";
        }
        else if (selectedTrack == "Select2")
        {
            trackName = "Track 2";
        }

        // Load the mapped scene name
        if (!string.IsNullOrEmpty(trackName))
        {
            SceneManager.LoadScene(trackName);
        }
        else
        {
            Debug.LogError("Selected track does not have a corresponding scene name.");
        }
    }

}
