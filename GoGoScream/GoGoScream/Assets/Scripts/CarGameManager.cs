using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGameManager : MonoBehaviour
{

    public int index;
    public GameObject[] cars;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");
        GameObject car = Instantiate(cars[index], Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
