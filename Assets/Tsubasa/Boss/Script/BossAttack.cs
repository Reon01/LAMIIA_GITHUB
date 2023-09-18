using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float CoolTime;   //攻撃のクールタイム


    private float countTime;　　　　　 //タイマー

    private int attackType;

    //はるまサウンド用変数
    public static bool Spear_Sound = false;

    //ボス攻撃用オブジェクト

    public GameObject Speir;

    public GameObject chaseZako;

    Test chaseZakos;

    public BossAttackState state;

    private void Awake()
    {
        chaseZakos = GameObject.Find("ZakoAttackBox").GetComponent<Test>();

        attackType = 0;
    }

    public enum BossAttackState
    {
        Spier,
        ChaseZako,
        ChaseZakos,
    }


    void Update()
    {
        
        countTime += Time.deltaTime;

        if (countTime > CoolTime)
        {
            
            attackType = Random.Range(0, 3);

            Debug.Log(attackType);

            //StateHandler();

            StateHandler();

            countTime = 0;

        }
              

    }

    private void StateHandler()
    {
        
        if (attackType == 0)
        {
            state = BossAttackState.Spier;
            SpeirAttackSet();
            Debug.Log("槍攻撃");
        }
        else if(attackType == 1)
        {
            state = BossAttackState.ChaseZako;
            //ChaseZako();
            Debug.Log("雑魚攻撃");
        }
        else if(attackType == 2)
        {
            state = BossAttackState.ChaseZakos;
            ChaseZakos();
            Debug.Log("複数雑魚攻撃");
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

    private void ChaseZako()
    {
        Instantiate(chaseZako, transform.position, Quaternion.identity);
    }

    private void ChaseZakos()
    {
        chaseZakos.oneShotFlag = true;

    }
}
