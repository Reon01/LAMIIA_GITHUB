using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip2 : MonoBehaviour
{
    GameObject[] tagObjects;
    public GameObject nextcanvas;
    public GameObject panel2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (tagObjects.Length == 0)
        {
            nextcanvas.SetActive(true);
            panel2.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
