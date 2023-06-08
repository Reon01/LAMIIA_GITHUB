using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpier : MonoBehaviour
{
    /*このスクリプトは槍攻撃の槍の軌道処理について記述している*/

    [Header("到達時間")]
    [SerializeField, Tooltip("到達時間")] float period; //槍が届くまでの時間
    
    [Header("最大加速度")]
    [SerializeField] float maxAcceleration = 100;　　   //加速度の制限

    [Header("ランダムに加える力")]
    [SerializeField] float randomPower;　               //発射時にランダムな力を加える　　　　　　　 
    [SerializeField] float randomPeriod;　　　　　　　  //ランダムな力を加える時間

    private GameObject target;　　　　　                //ターゲットのオブジェクト
    private Vector3 position;　　　　　　　　　　　　　 //発射ポジション

    public Vector3 velocity;                            //速度

    private void Update()
    {
        //Playerの情報を格納
        target = GameObject.FindGameObjectWithTag("Player");

        //発射位置
        position = transform.position;

        //ターゲットが存在しない場合これ以降の処理を行わない
        if (target == null)
            return;

        //加速度のベクトルを(0,0,0)に設定
        var acceleration = Vector3.zero;

        //発射位置からPlayerまでのベクトルを距離とする
        var diff = target.transform.position - position;

        //加速度　→　速度velocityの物体がperiod秒後にdiff進むための加速度
        acceleration += (diff - velocity * period) * 2f / (period * period);

        //randomPeriodが0になるまでランダムな力を加える
        if (0 < randomPeriod)
        {
            var xr = Random.Range(-randomPower, randomPower);
            var yr = Random.Range(-randomPower, randomPower);
            var zr = Random.Range(-randomPower, randomPower);
            acceleration += new Vector3(xr, yr, zr);
        }

        //加速度ベクトルがmaxAccelerationを超えるとき
        if (acceleration.magnitude > maxAcceleration)
        {
            //加速度がmaxAccelerationを超えないよう設定
            acceleration = acceleration.normalized * maxAcceleration;
        }

        period -= Time.deltaTime;
        randomPeriod -= Time.deltaTime;

        if (period < 0f)
            return;


        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;


    }

}
