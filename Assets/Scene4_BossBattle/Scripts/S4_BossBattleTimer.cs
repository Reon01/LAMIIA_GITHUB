using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4_BossBattleTimer : MonoBehaviour
{
    public Slider slider_bosstimer;
    public float timer;
    private bool istimer;
    public GameObject boss;
    public GameObject canvas_boss;
    private GameObject enemyspawn;
    public GameObject canvas_skillchargetimer;
    public Text text_timer; //テキストで時間表記
    public GameObject canvas_bosshit;

    // Start is called before the first frame update
    void Start()
    {
        enemyspawn = GameObject.Find("EnemySpawn");
        timer = slider_bosstimer.value;
        istimer = true;
        timer = 30;　//最初に30秒を指定する
    }

    // Update is called once per frame
    void Update()
    {
        slider_bosstimer.value = timer; //スライダーと時間を合わせる
        text_timer.text = "Time Limit：" + timer.ToString("f0"); //テキストで残り時間表記
        if (istimer == true)
        {
            timer -= Time.deltaTime; //１秒ずつ減らす
            if (timer <= 0)　//もしタイマーが０になった場合
            {
                canvas_bosshit.SetActive(false); //接触中のゲージを消す
                enemyspawn.GetComponent<S4_EnemySpawn>().enemyspawn2();
                canvas_skillchargetimer.SetActive(true);
                canvas_skillchargetimer.GetComponent<S4_SkillChargeTimer>().timerstart();
                boss.SetActive(false);
                canvas_boss.SetActive(false);
                timer = 30;
                istimer = false;

                //サウンド用
                PCExpander.bossObjChk = false;
            }
        }
    }

    public void timerstart()
    {
        istimer = true;
    }
}
