using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Kajiki : MonoBehaviour
{
    public GameObject Canvas_SkillSelect;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //PlayerオブジェクトについてるKajikiスクリプトからisSkillをtrueに変えてスキルを変更する
        Player.GetComponent<Kajiki>().isSkill = true;
        //スクリプトをオンにする
        Player.GetComponent<Kajiki>().enabled = true;


        //他のスキルをオフにする
        Player.GetComponent<Kurage>().isSkill = false;
        Player.GetComponent<SkillElectronic>().isSkill = false;
        //スクリプトごとオフにする
        Player.GetComponent<Kurage>().enabled = false;
        Player.GetComponent<SkillElectronic>().enabled = false;

        //カーソル非表示
        Cursor.visible = false;
        //カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;

        //他のボタンを非表示にする
        Canvas_SkillSelect.SetActive(false);
    }
}
