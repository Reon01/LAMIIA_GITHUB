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
        //サウンド用
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
        GetComponent<InputGetSkill>().a_Unagi -= 1; //スキルを１消費
    }

    public void Electronic()
    {
        //isSkillがtrueで、ウナギが１つ以上所持していた場合
        if (isSkill == true && enemykillsystem.GetComponent<EnemyKillTute>().a_Unagi >= 1&&Time.timeScale==1)
        {
            //Lightning.SetActive(true);　//雷のエフェクトをオンにする
            biglightning.SetActive(true);
            IsLightning = true; //IsLightningをtrueにする
            spend(); //spend()を実行する
            enemykillsystem.GetComponent<EnemyKillTute>().a_Unagi -= 1; //スキルを１消費
            iscount = true; //iscountをオンにする
            isSkill = false;　//isSKillをオフにする
            unagitimer.GetComponent<UnagiTimer>().iscount = true; //ウナギタイマーについてるUnagiTimer
                                                                  //というスクリプトをオンにする
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
