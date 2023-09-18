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

    //�{�X�U���p�I�u�W�F�N�g

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
            Debug.Log("���U��");
        }
        else if(attackType == 1)
        {
            state = BossAttackState.ChaseZako;
            //ChaseZako();
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
        chaseZakos.oneShotFlag = true;

    }
}
