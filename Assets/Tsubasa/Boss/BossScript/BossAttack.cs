using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    /*���̃X�N���v�g��Boss�̍U�������ɂ��ċL�q���Ă���*/

    [SerializeField] float CoolTime;   //Boss�̍U���Ԋu

    private float countTime;�@�@�@�@�@ //�^�C�}�[



    public GameObject Speir;�@�@�@�@�@ //���̃v���n�u


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
    /// �������֐�
    /// </summary>
    private void SpeirAttackSet()
    {
        Instantiate(Speir, transform.position, Quaternion.identity);
    }
}
