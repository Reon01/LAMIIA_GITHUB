using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSkillElectronic : MonoBehaviour
{
    public GameObject Lightning;
    public bool IsLightning;
    public bool isSkill;

    public bool iscount;
    public float count;

    private GameObject unagitimer;

    //�͂�܃T�E���h�p�ϐ�
    public static int EE_Sound = 0;


    // Start is called before the first frame update
    void Start()
    {
        IsLightning = false;
        unagitimer = GameObject.Find("UnagiTimer");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spend()
    {
        GetComponent<InputGetSkill>().a_Unagi -= 1; //�X�L�����P����
    }

    public void Electronic()
    {
        //isSkill��true�ŁA�E�i�M���P�ȏ㏊�����Ă����ꍇ
        if (isSkill == true && GetComponent<InputGetSkill>().a_Unagi >= 1)
        {
            //Lightning.SetActive(true);�@//���̃G�t�F�N�g���I���ɂ���
            IsLightning = true; //IsLightning��true�ɂ���
            spend(); //spend()�����s����
            iscount = true; //iscount���I���ɂ���
            isSkill = false;�@//isSKill���I�t�ɂ���
            unagitimer.GetComponent<UnagiTimer>().iscount = true; //�E�i�M�^�C�}�[�ɂ��Ă�UnagiTimer
                                                                  //�Ƃ����X�N���v�g���I���ɂ���

            EE_Sound = 1;
        }
    }

}
