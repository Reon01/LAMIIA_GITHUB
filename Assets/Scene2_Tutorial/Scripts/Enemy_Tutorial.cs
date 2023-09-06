using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tutorial : MonoBehaviour
{
    public GameObject enemy; 
    public bool isspawn;
    public GameObject[] tagObjects;

    public GameObject enemyF;
    public bool isspawnF;
    public GameObject[] tagObjectsF;

    // Start is called before the first frame update
    void Start()
    {
        //↓敵１体召喚
        Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.Euler(0,180,0));
        isspawn = true;

        Instantiate(enemyF, new Vector3(-4f, 0f, 6f), Quaternion.Euler(0, 180, 0));
        isspawnF = true;
    }

    // Update is called once per frame
    void Update()
    {
        //↓も常にEnemyタグを検知
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
        tagObjectsF = GameObject.FindGameObjectsWithTag("EnemyF");

        //↓もしEnemyタグが0だった場合
        if (tagObjects.Length == 0 && isspawn == true)
        {
            Invoke(nameof(enemyspawn),2f); //2f後にenemyspawn()を実行
            isspawn = false;
        }

        if (tagObjectsF.Length == 0 && isspawnF == true)
        {
            Invoke(nameof(enemyspawnF), 2f); //2f後にenemyspawn()を実行
            isspawnF = false;
        }
    }

    public void enemyspawn() //敵を1体召喚
    {
        Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.Euler(0, 180, 0));
        isspawn = true;
    }

    public void enemyspawnF() //敵を1体召喚
    {
        Instantiate(enemyF, new Vector3(-15f, 0f, 6f), Quaternion.Euler(0, 180, 0));
        isspawnF = true;
    }
}
