using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tutorial : MonoBehaviour
{
    public GameObject enemy; 
    public bool isspawn;
    public GameObject[] tagObjects;

    // Start is called before the first frame update
    void Start()
    {
        //↓敵１体召喚
        Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.identity);
        isspawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //↓も常にEnemyタグを検知
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");

        //↓もしEnemyタグが0だった場合
        if (tagObjects.Length == 0 && isspawn == true)
        {
            Invoke(nameof(enemyspawn),2f); //2f後にenemyspawn()を実行
            isspawn = false;
        }
    }

    public void enemyspawn() //敵を1体召喚
    {
        Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.identity);
        isspawn = true;
    }
}
