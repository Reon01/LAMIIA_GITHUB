using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Turtle : MonoBehaviour
{
    public PlayableDirector playabledirector;
    public GameObject turtle;
    private float i;
    private bool istime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            turtle.SetActive(true);
            playabledirector.Play();
            istime = true;
        }

        if (istime == true)
        {
            i += Time.deltaTime;
            if (i >= 1)
            {
                turtle.SetActive(false);
                i = 0;
                istime = false;
            }
        }
    }
}
