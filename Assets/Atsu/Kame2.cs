using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kame2 : MonoBehaviour
{
    public GameObject Turtle;
    public float i;
    public bool iscount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Turtle.SetActive(true);
            iscount = true;
        }

        if (iscount == true)
        {
            i++;
            if (i >= 300)
            {
                Turtle.SetActive(false);
                i = 0;
                iscount = false;
            }
        }
    }
}
