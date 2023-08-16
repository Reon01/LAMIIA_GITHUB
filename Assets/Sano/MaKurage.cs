using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaKurage : MonoBehaviour
{
    public GameObject kuragesield, player;
    public int kuragesieldHP;
    public bool isSkill;

    //�͂�܃T�E���h�p
    public static bool Kurage_Sound_s = false;
    public static bool Kurage_Sound_e = false;

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
        //Scene3
        if (Input.GetMouseButtonDown(0) && kuragesield.activeSelf == false && isSkill == true &&
            enemykillsystem.GetComponent<EnemyKill>().a_Kurage >= 1)
        {
            kuragesield.SetActive(true);
            kuragesieldHP = 1;
            player.GetComponent<PlayerHP>().kaihuku();
            GetComponent<GetSkill>().a_Kurage -= 1; //�X�L�����P����

            //�͂�܃T�E���h�p�ϐ�true
            Kurage_Sound_s = true;
        }
        //Scene2
        if (Input.GetMouseButtonDown(0) && kuragesield.activeSelf == false && isSkill == true &&
            enemykillsystem.GetComponent<EnemyKillTute>().a_Kurage >= 1)
        {
            kuragesield.SetActive(true);
            kuragesieldHP = 1;
            player.GetComponent<PlayerHP>().kaihuku();
            enemykillsystem.GetComponent<EnemyKillTute>().a_Kurage -= 1; //�X�L�����P����

            //�͂�܃T�E���h�p�ϐ�true
            Kurage_Sound_s = true;
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
        Kurage_Sound_e = true;
    }
}
