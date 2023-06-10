using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSens : MonoBehaviour
{
    public Slider cameraslider;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<PlayerMove3>().kando = cameraslider.value;
    }
}
