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
            //player.GetComponent<Kurage>().damage();
            this.gameObject.SetActive(false); //非表示にする
        }
        else if (other.CompareTag("EnemyF"))
        {
            //player.GetComponent<Kurage>().damage();
            this.gameObject.SetActive(false);　//非表示にする
        }
    }
}
