using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4_SkillChargeTimer:MonoBehaviour
{
    public GameObject canvas_skillcharge;
    public Slider skillchargetimer;
    public float timer;
    private bool istimer;
    private GameObject enemydestroysystem;
    private GameObject bossspawnsystem;
    public GameObject bossbattletimer;

    // Start is called before the first frame update
    void Start()
    {
        istimer = true;
        timer = skillchargetimer.value;
        enemydestroysystem = GameObject.Find("EnemyDestroySystem");
        bossspawnsystem = GameObject.Find("BossSpawnSystem");
    }

    // Update is called once per frame
    void Update()
    {
        skillchargetimer.value = timer; //スライダーと時間を合わせる
        if (istimer == true)
        {
            timer -= Time.deltaTime; //１秒ずつ減らす
            if (timer <= 0)　//もしタイマーが０になった場合
            {
                canvas_skillcharge.SetActive(false); //時間表示のスライダーを非表示にする
                enemydestroysystem.GetComponent<S4_EnemyDestroySystem>().enabled = true; //←のスクリプトをオンにする
                timer = 30;　//タイマーを30にして繰り返し実行されないようにする
                istimer = false;　//istimerをオフにして繰り返し予防
                bossspawnsystem.GetComponent<S4_BossSpawnSystem>().BossSpawn(); //ボス召喚
                bossbattletimer.GetComponent<S4_BossBattleTimer>().timerstart();　//ボスタイマーを起動
            }
        }
    }

    public void timerstart()
    {
        istimer = true;
    }
}
