using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S3_SkillChange : MonoBehaviour
{
    public Button button_mori;
    public Button button_kajiki;
    public Button button_kurage;
    public Button button_unagi;

    private int count;
    private GameObject player;
    public GameObject mori;

    public bool isunagi;
    public GameObject Lightning;
    private GameObject fishskillsystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        count = 0;
        button_mori.image.color = Color.yellow;
        fishskillsystem = GameObject.Find("FishSkillSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            count += 1;

            //サウンド用
            SFXplayer.skillChange_Sound = true;
        }

        if (count == 0)
        {
            mori.GetComponent<mori>().enabled = true;
        }
        if (count == 1)
        {
            kajikicolor();
            mori.GetComponent<mori>().enabled = false;
        }
        if (count == 2)
        {
            kuragecolor();
        }
        if (count == 3)
        {
            unagicolor();
            mori.GetComponent<mori>().enabled = true;
            player.GetComponent<SkillElectronic_new>().enabled = true; //ウナギのスクリプトをオンにする
        }
        if (count == 4)
        {
            moricolor();
            count = 0;
            player.GetComponent<SkillElectronic_new>().enabled = false;　//ウナギのスクリプトをオフにする
            player.GetComponent<SkillElectronic_new>().IsLightning = false;　//ウナギダメージ２倍をオフにする
        }
    }

    public void moricolor()
    {
        //サウンド用
        SFXplayer.isUnagi_act = false;

        Lightning.SetActive(false); //電気のエフェクトをオフにする

        button_mori.image.color = Color.yellow;
        button_unagi.image.color = Color.white;

        //他のスキルをオフにする
        player.GetComponent<S3_Kajiki>().isSkill = false;
        //player.GetComponent<Kurage>().isSkill = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<S3_Kajiki>().enabled = false;
        //player.GetComponent<Kurage>().enabled = false;
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }

    public void kajikicolor()
    {
        button_kajiki.image.color = Color.yellow;
        button_mori.image.color = Color.white;

        //スキル選択
        //PlayerオブジェクトについてるKajikiスクリプトからisSkillをtrueに変えてスキルを変更する
        player.GetComponent<S3_Kajiki>().isSkill = true;
        //スクリプトをオンにする
        player.GetComponent<S3_Kajiki>().enabled = true;


        //他のスキルをオフにする
        fishskillsystem.GetComponent<FishSkillSystem>().iskurage = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }
    public void kuragecolor()
    {
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //PlayerオブジェクトについてるKurageスクリプトからisSkillをtrueに変えてスキルを変更する
        fishskillsystem.GetComponent<FishSkillSystem>().iskurage = true;

        //他のスキルをオフにする
        player.GetComponent<S3_Kajiki>().isSkill = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<S3_Kajiki>().enabled = false;
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }
    public void unagicolor()
    {
        //サウンド用
        SFXplayer.isUnagi_act = true;
        if (SkillElectronic.EE_Sound == 0)
        {
            SkillElectronic.EE_Sound = 1;
        }

        Lightning.SetActive(true);　//電気のエフェクトをオンにする

        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        player.GetComponent<SkillElectronic_new>().enabled = true;　//スクリプトをオンにする
        player.GetComponent<SkillElectronic_new>().isunagi = true;　//左のスクリプトのisunagiをtrueにする

        //他のスキルをオフにする
        player.GetComponent<S3_Kajiki>().isSkill = false;
        fishskillsystem.GetComponent<FishSkillSystem>().iskurage = false;
        //スクリプトごとオフにする
        player.GetComponent<S3_Kajiki>().enabled = false;
    }
}
