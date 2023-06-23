using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float CoolTime;   //攻撃のクールタイム

    private float countTime;　　　　　 //タイマー

    //はるまサウンド用変数
    public static bool Spear_Sound = false;

    public GameObject Speir;


    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime >= CoolTime)
        {
            countTime = 0;
            SpeirAttackSet();
        }

    }



    private void SpeirAttackSet()
    {
        //Instantiate(Speir, transform.position, Quaternion.identity);
        GameObject ball = (GameObject)Instantiate(Speir, transform.position, Quaternion.identity);
        Destroy(ball, 3f);
        Debug.Log("ボス攻撃１");

        //はるまサウンド用
        Spear_Sound = true;
    }
}
