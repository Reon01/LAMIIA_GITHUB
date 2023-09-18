using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float CoolTime;   //�U���̃N�[���^�C��

    private float countTime;�@�@�@�@�@ //�^�C�}�[

    private int attackType;

    //�͂�܃T�E���h�p�ϐ�
    public static bool Spear_Sound = false;

    public GameObject Speir;

    public GameObject chaseZako;

    Test chaseZakos;

    public BossAttackState state;

    private void Awake()
    {
        chaseZakos = GameObject.Find("ZakoAttackBox").GetComponent<Test>();

        chaseZakos.enabled = false;

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
            countTime = 0;

            attackType = Random.Range(0, 3);

            //StateHandler();
            
        }


       


        Debug.Log(attackType);

    }

    private void StateHandler()
    {
        chaseZakos.enabled = false;

        if (attackType == 0)
        {
            state = BossAttackState.Spier;

            Debug.Log("���U��");
        }
        else if(attackType == 1)
        {
            state = BossAttackState.ChaseZako;
            ChaseZako();
            Debug.Log("�G���U��");
        }
        else if(attackType == 2)
        {
            state = BossAttackState.ChaseZakos;
            ChaseZakos();
            Debug.Log("�����G���U��");
        }

        
    }


    private void SpeirAttackSet()
    {
        //Instantiate(Speir, transform.position, Quaternion.identity);
        GameObject ball = (GameObject)Instantiate(Speir, transform.position, Quaternion.identity);
        Destroy(ball, 3f);
        Debug.Log("�{�X�U���P");

        //�͂�܃T�E���h�p
        Spear_Sound = true;
    }

    private void ChaseZako()
    {
        Instantiate(chaseZako, transform.position, Quaternion.identity);
    }

    private void ChaseZakos()
    {
        chaseZakos.enabled = true;
    }
}
