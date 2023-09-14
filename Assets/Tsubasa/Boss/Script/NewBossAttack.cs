using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBossAttack : MonoBehaviour
{
    [SerializeField] float CoolTime;   //�U���̃N�[���^�C��

    private float countTime;�@�@�@�@�@ //�^�C�}�[

    //�͂�܃T�E���h�p�ϐ�
    public static bool Spear_Sound = false;

    //���U���I�u�W�F�N�g
    public GameObject Speir;        

    //�`�F�C�X�G���I�u�W�F�N�g
    public GameObject chaseZako;

    //�����G���̃`�F�C�X�U���I�u�W�F�N�g
    GameObject chaseZakoBox;

    public BossState state;

    public enum BossState
    {
        
    }
    



    private void Awake()
    {
        //�����G���̃`�F�C�X�U���p��Box��T���Ċi�[
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
    /// ���U��
    /// </summary>
    private void SpeirAttackSet()
    {
        //Instantiate(Speir, transform.position, Quaternion.identity);
        GameObject ball = (GameObject)Instantiate(Speir, transform.position, Quaternion.identity);
        Destroy(ball, 3f);
        Debug.Log("�{�X�U���P");

        //�͂�܃T�E���h�p
        Spear_Sound = true;
    }

    /// <summary>
    /// �`�F�C�X�G���U��
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
