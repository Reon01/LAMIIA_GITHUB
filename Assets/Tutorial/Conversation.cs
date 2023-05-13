using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    public GameObject b1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            p1.SetActive(true);
        }
    }

    public void onclick1()
    {
        p1.SetActive(false);
        p2.SetActive(true);
    }
}
