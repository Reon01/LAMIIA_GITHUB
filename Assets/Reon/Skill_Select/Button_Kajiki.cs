using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Kajiki : MonoBehaviour
{
    public GameObject Canvas_SkillSelect;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //Player�I�u�W�F�N�g�ɂ��Ă�Kajiki�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        Player.GetComponent<Kajiki>().isSkill = true;
        //�X�N���v�g���I���ɂ���
        Player.GetComponent<Kajiki>().enabled = true;


        //���̃X�L�����I�t�ɂ���
        Player.GetComponent<Kurage>().isSkill = false;
        Player.GetComponent<SkillElectronic>().isSkill = false;
        //�X�N���v�g���ƃI�t�ɂ���
        Player.GetComponent<Kurage>().enabled = false;
        Player.GetComponent<SkillElectronic>().enabled = false;

        //�J�[�\����\��
        Cursor.visible = false;
        //�J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;

        //���̃{�^�����\���ɂ���
        Canvas_SkillSelect.SetActive(false);
    }
}
