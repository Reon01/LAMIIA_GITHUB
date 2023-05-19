using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tutorial : MonoBehaviour
{
    public GameObject enemy;
    public float hp = 100;
    public GameObject enemyspawner;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.identity);
        //hp = enemy.GetComponent<EnemyHP>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        hp = enemy.GetComponent<EnemyHP>().HP;

        if (enemy.GetComponent<EnemyHP>().HP <= 0)
        {
            Instantiate(enemy, new Vector3(3f, 0f, 6f),Quaternion.identity);
        }
        */
    }

    public void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.identity);
            }
        }
    }
}
