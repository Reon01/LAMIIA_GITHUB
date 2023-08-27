using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPBar;
    public int HP = 100;

    //HP数字表示
    public Text Text_HP;
    public int HP_num = 100;

    //死んだときに表示する
    public GameObject canvas_restart;
    private GameObject cursorlocksystem;

    public GameObject hitdamege;
    public float redcooltime = 0.5f;

    //回復表記
    public GameObject canvas_heal;

    //はるまサウンド用変数
    public static bool damaged_Sound_P = false;

    // Start is called before the first frame update
    void Start()
    {
        cursorlocksystem = GameObject.Find("CursorLockSystem");
    }

    // Update is called once per frame
    void Update()
    {
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;

        if (HP <= 0)
        {
            dead();
        }
    }

    //プレイヤーがダメージを受けた時の処理
    public void damage()
    {
        damaged_Sound_P = true;
        HP -= 5; //TSG向けに１０ダメから５ダメに変更
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void redeffect()
    {
        hitdamege.SetActive(true);
        Invoke("redeffectoff", redcooltime);
        Debug.Log("赤エフェクト");
    }

    public void redeffectoff()
    {
        hitdamege.SetActive(false);
    }

    public void fivedamage()
    {
        damaged_Sound_P = true;
        HP -= 2; //TSG向けに５ダメから２ダメに変更
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void speirdamage()
    {
        damaged_Sound_P = true;
        HP -= 2; //TSG向けに５ダメから２ダメに変更
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void kaihuku()
    {
        if (HP <= 99) //HPが９９以下の時のみ回復できる（HP上限は１０５）
        {
            HP += 10;
            HPBar.value = HP;
            HP_num = HP;
            Text_HP.text = "HP:" + HP_num;
            Debug.Log("クラゲ回復");
            canvas_heal.SetActive(true); //回復表記
            Invoke("healend", 1f); //２秒後に回復表記をオフ
        }
    }

    public void healend()　
    {
        canvas_heal.SetActive(false); //回復表記をオフ
    }

    public void maxheal()
    {
        HP = 100;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        Debug.Log("maxheal");
    }

    public void dead()
    {
        canvas_restart.SetActive(true);
        Time.timeScale = 0;
        cursorlocksystem.GetComponent<CursorLockSystem>().cursoropen();
        Debug.Log("死んだｗ");
    }
}
