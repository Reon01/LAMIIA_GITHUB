using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBossAttack : MonoBehaviour
{
    [SerializeField] float CoolTime;   //攻撃のクールタイム

    private float countTime;　　　　　 //タイマー

    //はるまサウンド用変数
    public static bool Spear_Sound = false;

    //槍攻撃オブジェクト
    public GameObject Speir;        

    //チェイス雑魚オブジェクト
    public GameObject chaseZako;

    //複数雑魚のチェイス攻撃オブジェクト
    GameObject chaseZakoBox;

    public BossState state;

    public enum BossState
    {
        
    }
    



    private void Awake()
    {
        //複数雑魚のチェイス攻撃用のBoxを探して格納
        chaseZakoBox = GameObject.Find("ZakoAttackBox ");

        chaseZakoBox.SetActive(false);
    }

    private void BossStateHandler()
    {

    }

    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime >= CoolTime)
        {
            countTime = 0;
            
        }

        ChaseZakoAttacks();

    }

   


    /// <summary>
    /// 槍攻撃
    /// </summary>
    private void SpeirAttackSet()
    {
        //Instantiate(Speir, transform.position, Quaternion.identity);
        GameObject ball = (GameObject)Instantiate(Speir, transform.position, Quaternion.identity);
        Destroy(ball, 3f);
        Debug.Log("ボス攻撃１");

        //はるまサウンド用
        Spear_Sound = true;
    }

    /// <summary>
    /// チェイス雑魚攻撃
    /// </summary>
    private void CaseZakoAttack()
    {
        Instantiate(chaseZako, transform.position, Quaternion.identity);
    }

    private void ChaseZakoAttacks()
    {
        chaseZakoBox.SetActive(true);
    }




}
