using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpier : MonoBehaviour
{
    /*���̃X�N���v�g�͑��U���̑��̋O�������ɂ��ċL�q���Ă���*/

    [Header("���B����")]
    [SerializeField, Tooltip("���B����")] float period; //�����͂��܂ł̎���
    
    [Header("�ő�����x")]
    [SerializeField] float maxAcceleration = 100;�@�@   //�����x�̐���

    [Header("�����_���ɉ������")]
    [SerializeField] float randomPower;�@               //���ˎ��Ƀ����_���ȗ͂�������@�@�@�@�@�@�@ 
    [SerializeField] float randomPeriod;�@�@�@�@�@�@�@  //�����_���ȗ͂������鎞��

    private GameObject target;�@�@�@�@�@                //�^�[�Q�b�g�̃I�u�W�F�N�g
    private Vector3 position;�@�@�@�@�@�@�@�@�@�@�@�@�@ //���˃|�W�V����

    public Vector3 velocity;                            //���x

    private void Update()
    {
        //Player�̏����i�[
        target = GameObject.FindGameObjectWithTag("Player");

        //���ˈʒu
        position = transform.position;

        //�^�[�Q�b�g�����݂��Ȃ��ꍇ����ȍ~�̏������s��Ȃ�
        if (target == null)
            return;

        //�����x�̃x�N�g����(0,0,0)�ɐݒ�
        var acceleration = Vector3.zero;

        //���ˈʒu����Player�܂ł̃x�N�g���������Ƃ���
        var diff = target.transform.position - position;

        //�����x�@���@���xvelocity�̕��̂�period�b���diff�i�ނ��߂̉����x
        acceleration += (diff - velocity * period) * 2f / (period * period);

        //randomPeriod��0�ɂȂ�܂Ń����_���ȗ͂�������
        if (0 < randomPeriod)
        {
            var xr = Random.Range(-randomPower, randomPower);
            var yr = Random.Range(-randomPower, randomPower);
            var zr = Random.Range(-randomPower, randomPower);
            acceleration += new Vector3(xr, yr, zr);
        }

        //�����x�x�N�g����maxAcceleration�𒴂���Ƃ�
        if (acceleration.magnitude > maxAcceleration)
        {
            //�����x��maxAcceleration�𒴂��Ȃ��悤�ݒ�
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
