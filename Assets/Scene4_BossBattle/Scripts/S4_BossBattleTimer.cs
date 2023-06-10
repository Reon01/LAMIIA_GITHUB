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

    // Start is called before the first frame update
    void Start()
    {
        enemyspawn = GameObject.Find("EnemySpawn");
        timer = slider_bosstimer.value;
        istimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        slider_bosstimer.value = timer; //スライダーと時間を合わせる
        if (istimer == true)
        {
            timer -= Time.deltaTime; //１秒ずつ減らす
            if (timer <= 0)　//もしタイマーが０になった場合
            {
                enemyspawn.GetComponent<S4_EnemySpawn>().enemyspawn2();
                canvas_skillchargetimer.SetActive(true);
                canvas_skillchargetimer.GetComponent<S4_SkillChargeTimer>().timerstart();
                boss.SetActive(false);
                canvas_boss.SetActive(false);
                timer = 30;
                istimer = false;
            }
        }
    }

    public void timerstart()
    {
        istimer = true;
    }
}
