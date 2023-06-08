using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    /*このスクリプトはBossの攻撃処理について記述している*/

    [SerializeField] float CoolTime;   //Bossの攻撃間隔

    private float countTime;　　　　　 //タイマー



    public GameObject Speir;　　　　　 //槍のプレハブ


    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime >= CoolTime)
        {
            countTime = 0;
            SpeirAttackSet();
        }

    }


    /// <summary>
    /// 槍生成関数
    /// </summary>
    private void SpeirAttackSet()
    {
        Instantiate(Speir, transform.position, Quaternion.identity);
    }
}
