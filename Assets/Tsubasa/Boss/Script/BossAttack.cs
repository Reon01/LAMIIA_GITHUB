using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float CoolTime;   //�U���̃N�[���^�C��

    private float countTime;�@�@�@�@�@ //�^�C�}�[

    //�͂�܃T�E���h�p�ϐ�
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
        Debug.Log("�{�X�U���P");

        //�͂�܃T�E���h�p
        Spear_Sound = true;
    }
}
