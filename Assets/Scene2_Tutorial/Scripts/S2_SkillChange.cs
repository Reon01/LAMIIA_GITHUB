using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2_SkillChange : MonoBehaviour
{
    public Button button_mori;
    public Button button_kajiki;
    public Button button_kurage;
    public Button button_unagi;

    private int count;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            count += 1;
        }

        if (count == 0)
        {
            player.GetComponent<mori>().enabled = true;
        }
        if (count == 1)
        {
            kajikicolor();
            player.GetComponent<mori>().enabled = false;
        }
        if (count == 2)
        {
            kuragecolor();
        }
        if (count == 3)
        {
            unagicolor();
            player.GetComponent<mori>().enabled = true;
        }
        if (count == 4)
        {
            count = 0;
        }
    }

    public void kajikicolor()
    {
        button_kajiki.image.color = Color.yellow;
        button_unagi.image.color = Color.white;

        //�X�L���I��
        //Player�I�u�W�F�N�g�ɂ��Ă�Kajiki�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<Kajiki>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<Kajiki>().enabled = true;


        //���̃X�L�����I�t�ɂ���
        player.GetComponent<Kurage>().isSkill = false;
        player.GetComponent<SkillElectronic>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<Kurage>().enabled = false;
        player.GetComponent<SkillElectronic>().enabled = false;
    }
    public void kuragecolor()
    {
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //Player�I�u�W�F�N�g�ɂ��Ă�Kurage�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<Kurage>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<Kurage>().enabled = true;

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<Kajiki>().isSkill = false;
        player.GetComponent<SkillElectronic>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<Kajiki>().enabled = false;
        player.GetComponent<SkillElectronic>().enabled = false;
    }
    public void unagicolor()
    {
        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        //Player�I�u�W�F�N�g�ɂ��Ă�Kurage�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        player.GetComponent<SkillElectronic>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        player.GetComponent<SkillElectronic>().enabled = true;

        //���̃X�L�����I�t�ɂ���
        player.GetComponent<Kajiki>().isSkill = false;
        player.GetComponent<Kurage>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        player.GetComponent<Kajiki>().enabled = false;
        player.GetComponent<Kurage>().enabled = false;
    }
}