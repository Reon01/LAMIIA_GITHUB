using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSkillElectronic : MonoBehaviour
{
    public GameObject Lightning;
    public GameObject biglightning;
    public bool IsLightning;
    public bool isSkill;

    public bool iscount;
    public float count;

    private GameObject enemykillsystem;
    private GameObject unagitimer;

    // Start is called before the first frame update
    void Start()
    {
        IsLightning = false;
        unagitimer = GameObject.Find("UnagiTimer");
        enemykillsystem = GameObject.Find("EnemyKillSystem");
    }

    // Update is called once per frame
    void Update()
    {
        //�T�E���h�p
        if (enemykillsystem.GetComponent<EnemyKillTute>().a_Unagi >= 1)
        {
            SFXplayer.c_Unagi_S = true;
        }
        else
        {
            SFXplayer.c_Unagi_S = false;
        }
    }

    public void spend()
    {
        GetComponent<InputGetSkill>().a_Unagi -= 1; //�X�L�����P����
    }

    public void Electronic()
    {
        //isSkill��true�ŁA�E�i�M���P�ȏ㏊�����Ă����ꍇ
        if (isSkill == true && enemykillsystem.GetComponent<EnemyKillTute>().a_Unagi >= 1&&Time.timeScale==1)
        {
            //Lightning.SetActive(true);�@//���̃G�t�F�N�g���I���ɂ���
            biglightning.SetActive(true);
            IsLightning = true; //IsLightning��true�ɂ���
            spend(); //spend()�����s����
            enemykillsystem.GetComponent<EnemyKillTute>().a_Unagi -= 1; //�X�L�����P����
            iscount = true; //iscount���I���ɂ���
            isSkill = false;�@//isSKill���I�t�ɂ���
            unagitimer.GetComponent<UnagiTimer>().iscount = true; //�E�i�M�^�C�}�[�ɂ��Ă�UnagiTimer
                                                                  //�Ƃ����X�N���v�g���I���ɂ���
            Invoke("lightningoff", 30f * Time.deltaTime);

            SFXplayer.EE_Sound = 2;
        }
    }

    public void lightningoff()
    {
        IsLightning = false;
        biglightning.SetActive(false);
    }

}
