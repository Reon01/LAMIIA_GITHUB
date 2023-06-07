using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_BossSpawnSystem : MonoBehaviour
{
    public GameObject canvas_boss;
    public GameObject boss;
    private GameObject bossbattletimer;

    // Start is called before the first frame update
    void Start()
    {
        bossbattletimer = GameObject.Find("BossBattleTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossSpawn()
    {
        canvas_boss.SetActive(true); //タイマー、体力を表示
        boss.SetActive(true);   //ボス召喚
        bossbattletimer.GetComponent<S4_BossBattleTimer>().enabled = true;  //タイマーのスクリプト起動
    }
}
