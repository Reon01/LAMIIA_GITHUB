using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S3_SkillChange : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            count += 1;

            //�T�E���h�p
            SFXplayer.skillChange_Sound = true;
        }

        if (count == 0)
        {
            mori.GetComponent<mori>().enabled = true;
        }
        if (count == 1)
        {
            kajikicolor();
            mori.GetComponent<mori>().enabled = false;
        }
        if (count == 2)
        {
            kuragecolor();
        }
        if (count == 3)
        {
            unagicolor();
            mori.GetComponent<mori>().enabled = true;
            player.GetComponent<SkillElectronic_new>().enabled = true; //�E�i�M�̃X�N���v�g���I���ɂ���
        }
        if (count == 4)
        {
            moricolor();
            count = 0;
            player.GetComponent<SkillElectronic_new>().enabled = false;�@//�E�i�M�̃X�N���v�g���I�t�ɂ���
            player.GetComponent<SkillElectronic_new>().IsLightning = false;�@//�E�i�M�_���[�W�Q�{���I�t�ɂ���
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
        player.GetComponent<S3_Kajiki>().isSkill = false;
        //player.GetComponent<Kurage>().isSkill = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<S3_Kajiki>().enabled = false;
        //player.GetComponent<Kurage>().enabled = false;
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }

    public void kajikicolor()
    {
        button_kajiki.image.color = Color.yellow;
        button_mori.image.color = Color.white;

        //�X�L���I��
        //Player�I�u�W�F�N�g�ɂ��Ă�Kajiki�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<S3_Kajiki>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<S3_Kajiki>().enabled = true;


        //���̃X�L�����I�t�ɂ���
        fishskillsystem.GetComponent<FishSkillSystem>().iskurage = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }
    public void kuragecolor()
    {
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //Player�I�u�W�F�N�g�ɂ��Ă�Kurage�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        fishskillsystem.GetComponent<FishSkillSystem>().iskurage = true;

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<S3_Kajiki>().isSkill = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<S3_Kajiki>().enabled = false;
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }
    public void unagicolor()
    {
        //�T�E���h�p
        SFXplayer.isUnagi_act = true;
        if (SkillElectronic.EE_Sound == 0)
        {
            SkillElectronic.EE_Sound = 1;
        }

        Lightning.SetActive(true);�@//�d�C�̃G�t�F�N�g���I���ɂ���

        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        player.GetComponent<SkillElectronic_new>().enabled = true;�@//�X�N���v�g���I���ɂ���
        player.GetComponent<SkillElectronic_new>().isunagi = true;�@//���̃X�N���v�g��isunagi��true�ɂ���

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<S3_Kajiki>().isSkill = false;
        fishskillsystem.GetComponent<FishSkillSystem>().iskurage = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<S3_Kajiki>().enabled = false;
    }
}
