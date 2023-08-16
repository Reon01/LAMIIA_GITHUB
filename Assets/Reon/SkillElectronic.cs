using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillElectronic : MonoBehaviour
{
    public GameObject Lightning;
    public GameObject biglightning;
    public bool IsLightning;
    public bool isSkill;

    public bool iscount;
    public float count;

    private GameObject unagitimer;

    //はるまサウンド用変数
    public static int EE_Sound = 0;

    private GameObject enemykillsystem;

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
        //もし左クリックして、isSkillがtrueで、ウナギが１つ以上所持していた場合
        if (Input.GetMouseButtonDown(0) && isSkill == true &&
            GetComponent<GetSkill>().a_Unagi >= 1)
        {
            Invoke("lightningoff", 30f * Time.deltaTime); //雷エフェクトを消す
            biglightning.SetActive(true);
            //Lightning.SetActive(true);　//雷のエフェクトをオンにする
            IsLightning = true; //IsLightningをtrueにする
            spend(); //spend()を実行する
            iscount = true; //iscountをオンにする
            isSkill = false;　//isSKillをオフにする
            unagitimer.GetComponent<UnagiTimer>().iscount = true; //ウナギタイマーについてるUnagiTimer
                                                                  //というスクリプトをオンにする

            EE_Sound = 1;
        }

        if (Input.GetMouseButtonDown(0) && isSkill == true && enemykillsystem.GetComponent<EnemyKillTute>().a_Unagi >= 1)
        {
            Invoke("lightningoff", 30f * Time.deltaTime); //雷エフェクトを消す
            biglightning.SetActive(true);
            //Lightning.SetActive(true);　//雷のエフェクトをオンにする
            IsLightning = true; //IsLightningをtrueにする
            enemykillsystem.GetComponent<EnemyKillTute>().a_Unagi -= 1; //スキルを１消費
            iscount = true; //iscountをオンにする
            isSkill = false;　//isSKillをオフにする
            unagitimer.GetComponent<UnagiTimer>().iscount = true; //ウナギタイマーについてるUnagiTimer
                                                                  //というスクリプトをオンにする

            EE_Sound = 1;
        }
    }
    public void lightningoff()
    {
        //IsLightning = false;
        biglightning.SetActive(false);
    }

    public void spend()
    {
        GetComponent<GetSkill>().a_Unagi -= 1; //スキルを１消費
    }
}
