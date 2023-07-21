using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputGetSkill : MonoBehaviour
{
    //�J�W�L
    public Text amount_Kajiki;�@//�c��̐���\�L����e�L�X�g
    public int a_Kajiki; //�����v�Z����
    private bool isKajiki; //�擾�G���A�ɂ��邩���Ȃ������f����

    //�E�i�M
    public Text amount_Unagi;�@//�c��̐���\�L����e�L�X�g
    public int a_Unagi; //�����v�Z����
    private bool isUnagi; //�擾�G���A�ɂ��邩���Ȃ������f����

    //�N���Q
    public Text amount_Kurage;�@//�c��̐���\�L����e�L�X�g
    public int a_Kurage; //�����v�Z����
    private bool isKurage; //�擾�G���A�ɂ��邩���Ȃ������f����

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�J�W�L�̃X�L�����g������A�\�L���[�P����
        if (GetComponent<Kajiki>().spendskill == true)
        {
            amount_Kajiki.text = "" + a_Kajiki;
        }
    }

    //�@���J�W�L�̃G���A�ɓ�������X�L�����擾�ł���悤�ɂ���
    public void OnTriggerEnter(Collider other)
    {
        //�J�W�L
        if (other.gameObject.CompareTag("Kajiki"))
        {
            isKajiki = true;
        }

        //�E�i�M
        if (other.gameObject.CompareTag("Unagi"))
        {
            isUnagi = true;
        }

        //�N���Q
        if (other.gameObject.CompareTag("Kurage"))
        {
            isKurage = true;
        }
    }

    //�@���J�W�L�̃G���A����o����擾�ł��Ȃ��悤�ɂ���
    public void OnTriggerExit(Collider other)
    {
        //�J�W�L
        if (other.gameObject.CompareTag("Kajiki"))
        {
            isKajiki = false;
        }

        //�E�i�M
        if (other.gameObject.CompareTag("Unagi"))
        {
            isUnagi = false;
        }

        //�N���Q
        if (other.gameObject.CompareTag("Kurage"))
        {
            isKurage = false;
        }
    }

    public void GetSkill()
    {
        amount_Kajiki.text = "" + a_Kajiki;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Unagi.text = "" + a_Unagi;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Kurage.text = "" + a_Kurage;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX

        //�J�W�L
        if (isKajiki == true)�@//�@�J�W�L�G���A�ɓ����Ă�Ƃ���E����������X�L�����P���炦��
        {
            a_Kajiki += 1;�@//�X�L���̐��{�P
        }

        //�E�i�M
        if (isUnagi == true)�@//�@�E�i�M�G���A�ɓ����Ă�Ƃ���E����������X�L�����P���炦��
        {
            a_Unagi += 1;�@//�X�L���̐��{�P
        }

        //�N���Q
        if (isKurage == true)�@//�@�N���Q�G���A�ɓ����Ă�Ƃ���E����������X�L�����P���炦��
        {
            a_Kurage += 1;�@//�X�L���̐��{�P
        }

       
    }
}
