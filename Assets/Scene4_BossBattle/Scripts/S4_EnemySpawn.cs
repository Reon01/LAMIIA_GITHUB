using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_EnemySpawn : MonoBehaviour
{
    private int enemyamount;
    public GameObject enemy1;

    //ランダムな位置生成
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    // Start is called before the first frame update
    void Start()
    {
        enemyamount = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyamount >= 0)
        {
            enemyspawn();
        }
    }

    public void enemyspawn()
    {
        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(enemy1, new Vector3(x, y, z), Quaternion.identity);
        enemyamount -= 1;
        Debug.Log("雑魚的召喚");
    }

    public void enemyspawn2()
    {
        enemyamount = Random.Range(5, 10);　//敵の数

        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(enemy1, new Vector3(x, y, z), Quaternion.identity);
        enemyamount -= 1;
        Debug.Log("雑魚的召喚");
    }
}
