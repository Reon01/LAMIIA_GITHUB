using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSkill : MonoBehaviour
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


    public GameObject SkillEfect;

    public float speed = 5f; // �G�t�F�N�g�̈ړ����x
    private Transform player; // �v���C���[��Transform

    public void EnemyDefeated(GameObject enemy)
    {
        GameObject skillEffect = Instantiate(SkillEfect, enemy.transform.position, Quaternion.identity);

        if (player != null)
        {
            // �v���C���[�̕���������
            transform.LookAt(player);

            // �v���C���[�̕����Ɉړ�
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // ���̎��Ԃ��o�߂�����G�t�F�N�g��j��
        Destroy(skillEffect, 2f);

        // �X�L���̎擾���������s
        GainSkill();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        amount_Kajiki.text = "" + a_Kajiki;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Unagi.text = "" + a_Unagi;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Kurage.text = "" + a_Kurage;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        */


    }
    void GainSkill()
    {
        //�J�W�L
        if (isKajiki == true && Input.GetKeyDown(KeyCode.E)) //�@�J�W�L�G���A�ɓ����Ă�Ƃ���E����������X�L�����P���炦��
        {
            a_Kajiki += 1; //�X�L���̐��{�P
        }

        //�E�i�M
        if (isUnagi == true && Input.GetKeyDown(KeyCode.E)) //�@�E�i�M�G���A�ɓ����Ă�Ƃ���E����������X�L�����P���炦��
        {
            a_Unagi += 1; //�X�L���̐��{�P
        }

        //�N���Q
        if (isKurage == true && Input.GetKeyDown(KeyCode.E)) //�@�N���Q�G���A�ɓ����Ă�Ƃ���E����������X�L�����P���炦��
        {
            a_Kurage += 1; //�X�L���̐��{�P
        }

        //�J�W�L�̃X�L�����g������A�\�L���[�P����
        if (GetComponent<Kajiki>().spendskill == true)
        {
            amount_Kajiki.text = "" + a_Kajiki;
        }
    }

    //�@���J�W�L�̃G���A�ɓ�������X�L�����擾�ł���悤�ɂ���
    void OnTriggerEnter(Collider other)
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
    void OnTriggerExit(Collider other)
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
}
