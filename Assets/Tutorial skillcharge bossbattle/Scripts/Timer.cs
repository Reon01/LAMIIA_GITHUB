using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 60;
    public GameObject canvas;
    public Slider slider_timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        slider_timer.value = timer;

        if (timer <= 0)
        {
            canvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
