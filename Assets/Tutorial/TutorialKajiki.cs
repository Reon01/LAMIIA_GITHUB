using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialKajiki : MonoBehaviour
{
    public Text amount_Kajiki;
    private bool skillget;
    private int a;

    // Start is called before the first frame update
    void Start()
    {
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (skillget == true)
        {
            amount_Kajiki.text = "" + a;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            a += 1;
            skillget = true;
        }
    }
}
