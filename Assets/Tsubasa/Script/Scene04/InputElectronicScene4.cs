using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputElectronicScene4 : MonoBehaviour
{
    public GameObject Lightning;
    public GameObject biglightning;
    public bool IsLightning;
    public bool isSkill;

    public bool iscount;
    public float count;
    private GameObject enemykillsystem;

    public bool isunagi;
    private GameObject player;
    private GameObject unagitimer;

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
            //unagitimer.GetComponent<S3_UnagiTimer>().iscount = true;

            SFXplayer.EE_Sound = 2;
        }

        /*
        if (enemykillsystem.GetComponent<EnemyKill>().a_Unagi >= 1)
        {
            IsLightning = true;
        }

        if (enemykillsystem.GetComponent<EnemyKill>().a_Unagi == 0)
        {
            IsLightning = false;
        }
        */

        if (enemykillsystem.GetComponent<EnemyKill>().a_Unagi >= 1)
        {
            SFXplayer.c_Unagi_S = true;
        }
        else
        {
            SFXplayer.c_Unagi_S = false;
        }
    }

    public void ElectronicScene4()
    {
        if (isunagi == true &&  enemykillsystem.GetComponent<EnemyKill>().a_Unagi >= 1)
        {
            skill();
            //unagitimer.GetComponent<S3_UnagiTimer>().iscount = true;

            SFXplayer.EE_Sound = 2;
        }

    }

    public void skill()
    {
        biglightning.SetActive(true);
        //Lightning.SetActive(true);
        IsLightning = true;
        //iscount = true;
        spend();
        Invoke("lightningoff", 30f * Time.deltaTime);
    }

    public void lightningoff()
    {
        IsLightning = false;
        biglightning.SetActive(false);
    }
    public void spend()
    {
        enemykillsystem.GetComponent<EnemyKill>().a_Unagi -= 1; //スキルを１消費
    }
}
