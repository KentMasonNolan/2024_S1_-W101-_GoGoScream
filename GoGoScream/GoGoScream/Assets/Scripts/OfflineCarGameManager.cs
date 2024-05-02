using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineCarGameManager : MonoBehaviour
{

    public int index;
    public GameObject[] cars;
    private Vector3 startPos = new Vector3(37, 0, 160);

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");
        GameObject car = Instantiate(cars[index], startPos, Quaternion.identity);
        car.name = "Player";
        car.AddComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
