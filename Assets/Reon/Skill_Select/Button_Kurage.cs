using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Kurage : MonoBehaviour
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
        //PlayerオブジェクトについてるKurageスクリプトからisSkillをtrueに変えてスキルを変更する
        Player.GetComponent<Kurage>().isSkill = true;

        //他のスキルをオフにする
        Player.GetComponent<Kajiki>().isSkill = false;
        Player.GetComponent<SkillElectronic>().isSkill = false;

        //カーソル非表示
        Cursor.visible = false;
        //カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;

        //他のボタンを非表示にする
        Canvas_SkillSelect.SetActive(false);
    }
}
