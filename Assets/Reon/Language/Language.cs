using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static int languageint = 0;
    public GameObject textcontroller;
    public GameObject textlabel;
    public GameObject textlabel_en;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (languageint == 0) //ì˙ñ{åÍê›íË
        {
            textlabel.SetActive(true);
            textlabel_en.SetActive(false);
            textcontroller.GetComponent<TextController>().enabled = true;
            textcontroller.GetComponent<TextController_EN>().enabled = false;
        }

        if (languageint == 1) //âpåÍê›íË
        {
            textlabel.SetActive(false);
            textlabel_en.SetActive(true);
            textcontroller.GetComponent<TextController>().enabled = false;
            textcontroller.GetComponent<TextController_EN>().enabled = true;
        }
    }

    public void japanese()
    {
        languageint = 0;
    }

    public void english()
    {
        languageint = 1;
    }
}
