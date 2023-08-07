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

    //ボスと重なった時の処理用
    public bool ishitboss;
    public float bosshitcount = 2;
    public GameObject canvas_bosshit;
    public Slider slider_enemyhit;

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

        //プレイヤーがボスと重なった時の処理
        if (ishitboss == true)
        {
            bosshitcount -= Time.deltaTime;
            slider_enemyhit.value = bosshitcount;
            if (bosshitcount <= 0)
            {
                fivedamage(); //５ダメ食らう
                bosshitcount = 2; //カウント2に戻す
            }
        }
    }

    //プレイヤーがボスと重なった時の処理
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            ishitboss = true; //カウントスタート
            canvas_bosshit.SetActive(true); //ダメージ警告表示
        }
    }
    //ボスとの重なりが終わった時
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            ishitboss = false; //カウントを止める
            bosshitcount = 2; //カウントを2に戻す
            canvas_bosshit.SetActive(false); //ダメージ警告非表示
        }
    }

    //プレイヤーがダメージを受けた時の処理
    public void damage()
    {
        damaged_Sound_P = true;
        HP -= 10;
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
        HP -= 5;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void speirdamage()
    {
        damaged_Sound_P = true;
        HP -= 5;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void kaihuku()
    {
        if (HP <= 90) //HPが９０以下の時のみ回復できる（HP上限は１００）
        {
            HP += 10;
            HPBar.value = HP;
            HP_num = HP;
            Text_HP.text = "HP:" + HP_num;
            Debug.Log("クラゲ回復");
        }
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
