using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KajikiHP : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Enemy") ||
            other.gameObject.CompareTag("MediumBoss")||
            other.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
