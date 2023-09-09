using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class INputSkillChange : MonoBehaviour
{
    public Button button_mori;
    public Button button_kajiki;
    public Button button_kurage;
    public Button button_unagi;

    private int count;
    private GameObject player;
    public GameObject mori;

    public GameObject Lightning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        count = 0;
        button_mori.image.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
       

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
        }
        if (count == 4)
        {
            moricolor();
            count = 0;
        }
    }



    public void SkillChange()
    { if(Time.timeScale == 1)
        {
            count += 1;
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
        player.GetComponent<InputKajiki>().isSkill = false;
        player.GetComponent<InputKurage>().isSkill = false;
        player.GetComponent<InputSkillElectronic>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputKajiki>().enabled = false;
        player.GetComponent<InputKurage>().enabled = false;
        player.GetComponent<InputSkillElectronic>().enabled = false;
    }

    public void kajikicolor()
    {
        button_kajiki.image.color = Color.yellow;
        button_mori.image.color = Color.white;

        //�X�L���I��
        //Player�I�u�W�F�N�g�ɂ��Ă�Kajiki�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<InputKajiki>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<InputKajiki>().enabled = true;


        //���̃X�L�����I�t�ɂ���
        player.GetComponent<InputKurage>().isSkill = false;
        player.GetComponent<InputSkillElectronic>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputKurage>().enabled = false;
        player.GetComponent<InputSkillElectronic>().enabled = false;
    }
    public void kuragecolor()
    {
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //Player�I�u�W�F�N�g�ɂ��Ă�Kurage�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<InputKurage>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<InputKurage>().enabled = true;

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<InputKajiki>().isSkill = false;
        player.GetComponent<InputSkillElectronic>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputKajiki>().enabled = false;
        player.GetComponent<InputSkillElectronic>().enabled = false;
    }
    public void unagicolor()
    {
        //�T�E���h�p
        SFXplayer.isUnagi_act = true;
        if (InputSkillElectronic.EE_Sound == 0)
        {
            InputSkillElectronic.EE_Sound = 1;
        }

        Lightning.SetActive(true);�@//�d�C�̃G�t�F�N�g���I���ɂ���

        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        //Player�I�u�W�F�N�g�ɂ��Ă�Kurage�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<InputSkillElectronic>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<InputSkillElectronic>().enabled = true;

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<InputKajiki>().isSkill = false;
        player.GetComponent<InputKurage>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<InputKajiki>().enabled = false;
        player.GetComponent<InputKurage>().enabled = false;
    }
}
