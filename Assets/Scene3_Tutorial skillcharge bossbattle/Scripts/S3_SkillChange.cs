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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            count += 1;
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
        }
        if (count == 4)
        {
            moricolor();
            count = 0;
        }
    }

    public void moricolor()
    {
        button_mori.image.color = Color.yellow;
        button_unagi.image.color = Color.white;

        //他のスキルをオフにする
        player.GetComponent<Kajiki>().isSkill = false;
        //player.GetComponent<Kurage>().isSkill = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<Kajiki>().enabled = false;
        //player.GetComponent<Kurage>().enabled = false;
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }

    public void kajikicolor()
    {
        button_kajiki.image.color = Color.yellow;
        button_mori.image.color = Color.white;

        //スキル選択
        //PlayerオブジェクトについてるKajikiスクリプトからisSkillをtrueに変えてスキルを変更する
        player.GetComponent<Kajiki>().isSkill = true;
        //スクリプトをオンにする
        player.GetComponent<Kajiki>().enabled = true;


        //他のスキルをオフにする
        //player.GetComponent<Kurage>().isSkill = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //スクリプトごとオフにする
        //player.GetComponent<Kurage>().enabled = false;
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }
    public void kuragecolor()
    {
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;

        //PlayerオブジェクトについてるKurageスクリプトからisSkillをtrueに変えてスキルを変更する
        //player.GetComponent<Kurage>().isSkill = true;
        //スクリプトをオンにする
        //player.GetComponent<Kurage>().enabled = true;

        //他のスキルをオフにする
        player.GetComponent<Kajiki>().isSkill = false;
        player.GetComponent<SkillElectronic_new>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<Kajiki>().enabled = false;
        player.GetComponent<SkillElectronic_new>().enabled = false;
    }
    public void unagicolor()
    {
        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;

        //PlayerオブジェクトについてるKurageスクリプトからisSkillをtrueに変えてスキルを変更する
        player.GetComponent<SkillElectronic_new>().isSkill = true;
        //スクリプトをオンにする
        player.GetComponent<SkillElectronic_new>().enabled = true;

        //他のスキルをオフにする
        player.GetComponent<Kajiki>().isSkill = false;
        //player.GetComponent<Kurage>().isSkill = false;
        //スクリプトごとオフにする
        player.GetComponent<Kajiki>().enabled = false;
        //player.GetComponent<Kurage>().enabled = false;
    }
}
