using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelection : MonoBehaviour
{

    public GameObject carSelect;
    public GameObject trackSelect;
    public string trackName;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(Button button)
    {
       trackName = button.name;
        carSelect.SetActive(true);
        trackSelect.SetActive(false);
        
    }

    public string getTrack()
    {
        return trackName;
    }
  
}
