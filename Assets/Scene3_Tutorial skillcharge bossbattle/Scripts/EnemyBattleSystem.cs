using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleSystem : MonoBehaviour
{
    public int enemyamount;
    public GameObject enemy1;
    public GameObject rareenemy;
    public int enemyamountsave;

    public float timer;

    private int enemygachanumber;

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
        enemyamount = Random.Range(10, 21);
        enemyamountsave = enemyamount;
        enemyamountsave += 1;
    }

    // Update is called once per frame
    void Update()
    {
        //もし敵の数が０だったら、ガチャスタート
        if (enemyamount >= 0)
        {
            enemygacha();
        }
    }

    //数字でガチャ（確率）を作る
    public void enemygacha()
    {
        enemygachanumber = Random.Range(0, 100);
        //70%の確率
        if (enemygachanumber >= 31)
        {
            normalenemyspawn();
        }
        //30%の確率
        if (enemygachanumber <= 30)
        {
            rareenemyspawn();
        }
    }

    //普通の敵を召喚
    public void normalenemyspawn()
    {
        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(enemy1, new Vector3(x,y,z), Quaternion.identity);
        enemyamount -= 1;
    }

    //レアな敵を召喚
    public void rareenemyspawn()
    {
        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(rareenemy, new Vector3(x, y, z), Quaternion.identity);
        enemyamount -= 1;
    }
}
