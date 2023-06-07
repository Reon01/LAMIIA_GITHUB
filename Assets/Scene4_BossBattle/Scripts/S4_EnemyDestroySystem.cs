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
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");   //'Enemy'タグを探す

        foreach (GameObject enemy in enemys)    //繰り返す
        {
            Destroy(enemy); //'Enemy'タグがついたオブジェクトを破壊する
        }

        if (enemys.Length <= 0)
        {
            //'Enemy'タグがついたオブジェクトがなくなったらこのスクリプトをオフにする
            this.GetComponent<S4_EnemyDestroySystem>().enabled = false;
        }

    }


}
