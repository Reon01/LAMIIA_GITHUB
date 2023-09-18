using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKurage : MonoBehaviour
{
    public GameObject kuragesield, player;
    public int kuragesieldHP;
    public bool isSkill;


    private GameObject enemykillsystem;

    // Start is called before the first frame update
    void Start()
    {
        kuragesield.SetActive(false);
        kuragesieldHP = 0;
        isSkill = false;
        enemykillsystem = GameObject.Find("EnemyKillSystem");
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void SkillKurage()
    {
        //Scene3
        if (kuragesield.activeSelf == false && isSkill == true &&
            enemykillsystem.GetComponent<EnemyKill>().a_Kurage >= 1)
        {
            kuragesield.SetActive(true);
            kuragesieldHP = 1;
            player.GetComponent<PlayerHP>().kaihuku();
            GetComponent<InputGetSkill>().a_Kurage -= 1; //�X�L�����P����

            //�͂�܃T�E���h�p�ϐ�true
            SFXplayer.Jf_S = 1;
        }

        if (kuragesieldHP <= 0)
        {
            kuragesield.SetActive(false);
            //Debug.Log("�N���Q����");
        }


        //Scene2
        if (kuragesield.activeSelf == false && isSkill == true &&
            enemykillsystem.GetComponent<EnemyKillTute>().a_Kurage >= 1)
        {
            kuragesield.SetActive(true);
            kuragesieldHP = 1;
            player.GetComponent<PlayerHP>().kaihuku();
            enemykillsystem.GetComponent<EnemyKillTute>().a_Kurage -= 1; //�X�L�����P����

            //�͂�܃T�E���h�p�ϐ�true
            SFXplayer.Jf_S = 1;
        }
        if (kuragesieldHP <= 0)
        {
            kuragesield.SetActive(false);
            //Debug.Log("�N���Q����");
        }
    }

    public void damage()
    {
        //kuragesieldHP -= 1;
        kuragesield.SetActive(false);
        Debug.Log("�N���Q����");

        //�T�E���h�p
        SFXplayer.Jf_S = 2;
    }

}
