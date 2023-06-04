using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleSystem : MonoBehaviour
{
    private int enemyamount;
    public GameObject enemy1;

    public float timer;

    //ランダムな位置生成
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    GameObject[] tagObjects; //タグの取得

    // Start is called before the first frame update
    void Start()
    {
        enemyamount = Random.Range(5, 10);
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyamount >= 0)
        {
            enemyspawn();
        }

        /*
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy")); //雑魚敵を殺す
            Debug.Log("雑魚敵排除");
        }
        else if (tagObjects.Length == 0)
        {
            timer = 1000000; //もう１度雑魚敵を殺さないようにタイマーをめっちゃ伸ばす
            Debug.Log("全滅");
        }
        */
    }

    public void enemyspawn()
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
}
