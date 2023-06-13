using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider slider_timer;
    public GameObject player;
    public GameObject warppoint;
    public GameObject mediumbosssystem;
    public GameObject mediumboss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider_timer.value <= 0)
        {
            warp();
            gameObject.SetActive(false);
        }
    }

    public void warp()
    {
        player.GetComponent<CharacterController>().enabled = false;
        Vector3 point = warppoint.transform.position;
        player.transform.position = point;
        mediumbosssystem.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
    }
}
