using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSkillChangeScene04 : MonoBehaviour
{
    public Button button_mori;
    public Button button_kajiki;
    public Button button_kurage;
    public Button button_unagi;


    private int count;
    private GameObject player;
    public GameObject mori;

    public bool isunagi;
    public GameObject Lightning;
    private GameObject fishskillsystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        count = 0;
        button_mori.image.color = Color.yellow;
        fishskillsystem = GameObject.Find("FishSkillSystem");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (count == 0)
        {
            mori.GetComponent<InputMoriAttack>().enabled = true;�@//��U����L����
        }
        if (count == 1)
        {
            kajikicolor();
            mori.GetComponent<InputMoriAttack>().enabled = false;�@//��U���𖳌���
        }
        if (count == 2)
        {
            kuragecolor();
            mori.GetComponent<InputMoriAttack>().enabled = true; //��U����L��
        }
        if (count == 3)
        {
            unagicolor();
            mori.GetComponent<InputMoriAttack>().enabled = true;�@//��U����L����
            player.GetComponent<InputElectronicScene4>().enabled = true; //�E�i�M�̃X�N���v�g���I���ɂ���
        }
        if (count == 4)
        {
            moricolor();
            count = 0;
            player.GetComponent<InputElectronicScene4>().enabled = false;�@//�E�i�M�̃X�N���v�g���I�t�ɂ���
            player.GetComponent<InputElectronicScene4>().IsLightning = false;�@//�E�i�M�_���[�W�Q�{���I�t�ɂ���
            player.GetComponent<InputElectronicScene4>().isunagi = false;�@//bool�^��isunagi���I�t�ɂ���
        }
    }

    public void SkillChangeScene04()
    {
        if (Time.timeScale == 1)
        {
            count += 1;

            //�T�E���h�p
            SFXplayer.skillChange_Sound = true;
        }
    }


    public void moricolor()
    {
        //�T�E���h�p
        SFXplayer.isUnagi_act = false;

        Lightning.SetActive(false); //�d�C�̃G�t�F�N�g���I�t�ɂ���

        button_mori.image.color = Color.yellow;
        button_unagi.image.color = Color.white;

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<InputKajikiScne04>().isSkill = false;
        //player.GetComponent<Kurage>().isSkill = false;
        player.GetComponent<InputElectronicScene4>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputKajikiScne04>().enabled = false;
        //player.GetComponent<Kurage>().enabled = false;
        player.GetComponent<InputElectronicScene4>().enabled = false;
    }

    public void kajikicolor()
    {
        //�T�E���h�p
        SFXplayer.isSf_act = true;

        button_kajiki.image.color = Color.yellow;
        button_mori.image.color = Color.white;

        //�X�L���I��
        //Player�I�u�W�F�N�g�ɂ��Ă�Kajiki�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<InputKajikiScne04>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<InputKajikiScne04>().enabled = true;


        //���̃X�L�����I�t�ɂ���
        fishskillsystem.GetComponent<InputKurageScene04>().iskurage = false;
        player.GetComponent<InputElectronicScene4>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputElectronicScene4>().enabled = false;
    }
    public void kuragecolor()
    {
        //�T�E���h�p
        SFXplayer.isSf_act = false;
        SFXplayer.isJf_act = true;
        
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //Player�I�u�W�F�N�g�ɂ��Ă�Kurage�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        fishskillsystem.GetComponent<InputKurageScene04>().iskurage = true;

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<InputKajikiScne04>().isSkill = false;
        player.GetComponent<InputElectronicScene4>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputKajikiScne04>().enabled = false;
        player.GetComponent<InputElectronicScene4>().enabled = false;
    }
    public void unagicolor()
    {
        //�T�E���h�p
        SFXplayer.isJf_act = false;
        SFXplayer.isUnagi_act = true;
        
        if (SFXplayer.EE_Sound == 0)
        {
            SFXplayer.EE_Sound = 1;
        }

        Lightning.SetActive(true);�@//�d�C�̃G�t�F�N�g���I���ɂ���

        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        player.GetComponent<InputElectronicScene4>().enabled = true;�@//�X�N���v�g���I���ɂ���
        player.GetComponent<InputElectronicScene4>().isunagi = true;�@//���̃X�N���v�g��isunagi��true�ɂ���

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<InputKajikiScne04>().isSkill = false;
        fishskillsystem.GetComponent<InputKurageScene04>().iskurage = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputKajikiScne04>().enabled = false;
    }
}
