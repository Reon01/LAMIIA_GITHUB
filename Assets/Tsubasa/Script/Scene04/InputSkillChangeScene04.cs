using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSkillChangeScene04 : MonoBehaviour
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
        
        if (count == 0)
        {
            mori.GetComponent<InputMoriAttack>().enabled = true;　//銛攻撃を有効化
        }
        if (count == 1)
        {
            kajikicolor();
            mori.GetComponent<InputMoriAttack>().enabled = false;　//銛攻撃を無効化
        }
        if (count == 2)
        {
            kuragecolor();
            mori.GetComponent<InputMoriAttack>().enabled = true; //銛攻撃を有効
        }
        if (count == 3)
        {
            unagicolor();
            mori.GetComponent<InputMoriAttack>().enabled = true;　//銛攻撃を有効化
            player.GetComponent<InputElectronicScene4>().enabled = true; //ウナギのスクリプトをオンにする
        }
        if (count == 4)
        {
            moricolor();
            count = 0;
            player.GetComponent<InputElectronicScene4>().enabled = false;　//ウナギのスクリプトをオフにする
            player.GetComponent<InputElectronicScene4>().IsLightning = false;　//ウナギダメージ２倍をオフにする
            player.GetComponent<InputElectronicScene4>().isunagi = false;　//bool型のisunagiをオフにする
        }
    }

    public void SkillChangeScene04()
    {
        if (Time.timeScale == 1)
        {
            count += 1;

            //サウンド用
            SFXplayer.skillChange_Sound = true;
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
        player.GetComponent<InputKajikiScne04>().isSkill = false;
        //player.GetComponent<Kurage>().isSkill = false;
        player.GetComponent<InputElectronicScene4>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<InputKajikiScne04>().enabled = false;
        //player.GetComponent<Kurage>().enabled = false;
        player.GetComponent<InputElectronicScene4>().enabled = false;
    }

    public void kajikicolor()
    {
        //サウンド用
        SFXplayer.isSf_act = true;

        button_kajiki.image.color = Color.yellow;
        button_mori.image.color = Color.white;

        //スキル選択
        //PlayerオブジェクトについてるKajikiスクリプトからisSkillをtrueに変えてスキルを変更する
        player.GetComponent<InputKajikiScne04>().isSkill = true;
        //スクリプトをオンにする
        player.GetComponent<InputKajikiScne04>().enabled = true;


        //他のスキルをオフにする
        fishskillsystem.GetComponent<InputKurageScene04>().iskurage = false;
        player.GetComponent<InputElectronicScene4>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<InputElectronicScene4>().enabled = false;
    }
    public void kuragecolor()
    {
        //サウンド用
        SFXplayer.isSf_act = false;
        SFXplayer.isJf_act = true;
        
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //PlayerオブジェクトについてるKurageスクリプトからisSkillをtrueに変えてスキルを変更する
        fishskillsystem.GetComponent<InputKurageScene04>().iskurage = true;

        //他のスキルをオフにする
        player.GetComponent<InputKajikiScne04>().isSkill = false;
        player.GetComponent<InputElectronicScene4>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<InputKajikiScne04>().enabled = false;
        player.GetComponent<InputElectronicScene4>().enabled = false;
    }
    public void unagicolor()
    {
        //サウンド用
        SFXplayer.isJf_act = false;
        SFXplayer.isUnagi_act = true;
        
        if (SFXplayer.EE_Sound == 0)
        {
            SFXplayer.EE_Sound = 1;
        }

        Lightning.SetActive(true);　//電気のエフェクトをオンにする

        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        player.GetComponent<InputElectronicScene4>().enabled = true;　//スクリプトをオンにする
        player.GetComponent<InputElectronicScene4>().isunagi = true;　//左のスクリプトのisunagiをtrueにする

        //他のスキルをオフにする
        player.GetComponent<InputKajikiScne04>().isSkill = false;
        fishskillsystem.GetComponent<InputKurageScene04>().iskurage = false;
        //スクリプトごとオフにする
        player.GetComponent<InputKajikiScne04>().enabled = false;
    }
}
