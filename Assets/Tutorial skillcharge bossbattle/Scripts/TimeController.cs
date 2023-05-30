using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider slider_timer;
    public GameObject player;
    public GameObject warppoint;

    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        //warppoint = GameObject.Find("WarpPoint");
        //Vector3 point = warppoint.transform.position;
        //x = point.x;
        //y = point.y;
        //z = point.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider_timer.value <= 0)
        {
            Vector3 point = warppoint.transform.position;
            player.transform.position = point;
            Debug.Log(point);
        }
    }
}
