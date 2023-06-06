using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_EnemyDestroySystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }

        if (enemys.Length <= 0)
        {
            this.GetComponent<S4_EnemyDestroySystem>().enabled = false;
        }

    }


}
