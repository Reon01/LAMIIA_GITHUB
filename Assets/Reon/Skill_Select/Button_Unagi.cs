using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Unagi : MonoBehaviour
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
        //Player�I�u�W�F�N�g�ɂ��Ă�Kurage�X�N���v�g����isSkill��true�ɕς��ăX�L����ύX����
        Player.GetComponent<SkillElectronic>().isSkill = true;

        //���̃X�L�����I�t�ɂ���
        Player.GetComponent<Kajiki>().isSkill = false;
        Player.GetComponent<Kurage>().isSkill = false;

        //�J�[�\����\��
        Cursor.visible = false;
        //�J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;

        //���̃{�^�����\���ɂ���
        Canvas_SkillSelect.SetActive(false);
    }
}
