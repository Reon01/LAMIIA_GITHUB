using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class INputSkillChange : MonoBehaviour
{
    public Button button_mori;
    public Button button_kajiki;
    public Button button_kurage;
    public Button button_unagi;

    private int count;
    private GameObject player;
    public GameObject mori;

    public GameObject Lightning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        count = 0;
        button_mori.image.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
       

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
        }
        if (count == 4)
        {
            moricolor();
            count = 0;
        }
    }



    public void SkillChange()
    { if(Time.timeScale == 1)
        {
            count += 1;
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
        player.GetComponent<InputKajiki>().isSkill = false;
        player.GetComponent<InputKurage>().isSkill = false;
        player.GetComponent<InputSkillElectronic>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<InputKajiki>().enabled = false;
        player.GetComponent<InputKurage>().enabled = false;
        player.GetComponent<InputSkillElectronic>().enabled = false;
    }

    public void kajikicolor()
    {
        button_kajiki.image.color = Color.yellow;
        button_mori.image.color = Color.white;

        //スキル選択
        //PlayerオブジェクトについてるKajikiスクリプトからisSkillをtrueに変えてスキルを変更する
        player.GetComponent<InputKajiki>().isSkill = true;
        //スクリプトをオンにする
        player.GetComponent<InputKajiki>().enabled = true;


        //他のスキルをオフにする
        player.GetComponent<InputKurage>().isSkill = false;
        player.GetComponent<InputSkillElectronic>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<InputKurage>().enabled = false;
        player.GetComponent<InputSkillElectronic>().enabled = false;
    }
    public void kuragecolor()
    {
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //PlayerオブジェクトについてるKurageスクリプトからisSkillをtrueに変えてスキルを変更する
        player.GetComponent<InputKurage>().isSkill = true;
        //スクリプトをオンにする
        player.GetComponent<InputKurage>().enabled = true;

        //他のスキルをオフにする
        player.GetComponent<InputKajiki>().isSkill = false;
        player.GetComponent<InputSkillElectronic>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<InputKajiki>().enabled = false;
        player.GetComponent<InputSkillElectronic>().enabled = false;
    }
    public void unagicolor()
    {
        //サウンド用
        SFXplayer.isUnagi_act = true;
        if (InputSkillElectronic.EE_Sound == 0)
        {
            InputSkillElectronic.EE_Sound = 1;
        }

        Lightning.SetActive(true);　//電気のエフェクトをオンにする

        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        //PlayerオブジェクトについてるKurageスクリプトからisSkillをtrueに変えてスキルを変更する
        player.GetComponent<InputSkillElectronic>().isSkill = true;
        //スクリプトをオンにする
        player.GetComponent<InputSkillElectronic>().enabled = true;

        //他のスキルをオフにする
        player.GetComponent<InputKajiki>().isSkill = false;
        player.GetComponent<InputKurage>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<InputKajiki>().enabled = false;
        player.GetComponent<InputKurage>().enabled = false;
    }
}
