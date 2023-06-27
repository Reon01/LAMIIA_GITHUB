using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip5 : MonoBehaviour
{
    public GameObject image_kurage;
    public GameObject image_unagi;
    public GameObject button_next;
    public GameObject button_back;

    // Start is called before the first frame update
    void Start()
    {
        image_kurage.SetActive(true);
        button_next.SetActive(true);
        button_back.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        image_unagi.SetActive(true);
        image_kurage.SetActive(false);
    }

    public void back()
    {
        image_unagi.SetActive(false);
        image_kurage.SetActive(true);
    }
}
