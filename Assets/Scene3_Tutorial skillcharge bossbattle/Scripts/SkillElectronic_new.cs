using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillElectronic_new : MonoBehaviour
{
    public GameObject Lightning;
    public bool IsLightning;
    public bool isSkill;

    public bool iscount;
    public float count;
    private GameObject enemykillsystem;

    public bool isunagi;
    private GameObject player;
    private GameObject unagitimer;

    //サウンド用
    public static bool c_Unagi_S = false;

    // Start is called before the first frame update
    void Start()
    {
        IsLightning = false;
        enemykillsystem = GameObject.Find("EnemyKillSystem");
        player = GameObject.Find("Player");
        unagitimer = GameObject.Find("UnagiTimer");
    }

    // Update is called once per frame
    void Update()
    {
        //↓ウナギを選択して左クリックしたらスキル発動
        if (isunagi == true && Input.GetMouseButtonDown(0) &&
            enemykillsystem.GetComponent<EnemyKill>().a_Unagi >= 1)
        {
            skill();
            unagitimer.GetComponent<S3_UnagiTimer>().iscount = true;

            SkillElectronic.EE_Sound = 2;
        }

        if (iscount == true)
        {
            count += Time.deltaTime;
            if (count >= 3)
            {
                Lightning.SetActive(false);
                IsLightning = false;
                count = 0;
                iscount = false;
            }
        }

        if (enemykillsystem.GetComponent<EnemyKill>().a_Unagi >= 1)
        {
            c_Unagi_S = true;
        }
        else
        {
            c_Unagi_S = false;
        }
    }

    public void skill()
    {
        Lightning.SetActive(true);
        IsLightning = true;
        //iscount = true;
        spend();
    }
    public void spend()
    {
        enemykillsystem.GetComponent<EnemyKill>().a_Unagi -= 1; //スキルを１消費
    }
}
