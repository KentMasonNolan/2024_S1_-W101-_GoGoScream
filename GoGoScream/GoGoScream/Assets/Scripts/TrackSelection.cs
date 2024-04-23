using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSelection : MonoBehaviour
{

    public GameObject carSelect;
    public GameObject trackSelect;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        carSelect.SetActive(true);
        trackSelect.SetActive(false);
        
    }
}
