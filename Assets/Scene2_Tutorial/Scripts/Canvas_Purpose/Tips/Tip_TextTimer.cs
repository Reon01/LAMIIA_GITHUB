using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip_TextTimer : MonoBehaviour
{
    public float timer;
    public GameObject nextcanvas;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            nextcanvas.SetActive(true);
            panel.SetActive(false);
            gameObject.GetComponent<Tip_TextTimer>().enabled = false;
        }
    }
}
