using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuragehit : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            player.GetComponent<Kurage>().damage();
        }
    }
}
