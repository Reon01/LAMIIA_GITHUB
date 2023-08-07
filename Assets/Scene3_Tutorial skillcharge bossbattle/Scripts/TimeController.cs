using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider slider_timer;
    public GameObject player;
    public GameObject warppoint;
    public GameObject mediumbosssystem;
    public GameObject mediumboss;

    private GameObject[] enemy;
    public int amount;
    public GameObject enemybattlesystem;
    //private GameObject skillcheat;
    public GameObject tip2;

    // Start is called before the first frame update
    void Start()
    {
        //skillcheat = GameObject.Find("SkillCheat");
    }

    // Update is called once per frame
    void Update()
    {
        amount = enemybattlesystem.GetComponent<EnemyBattleSystem>().enemyamountsave;
        if (slider_timer.value <= 0)
        {
            warp();
            /*
            enemy = GameObject.FindGameObjectsWithTag("Enemy");　//敵の数を数える
            if (enemy.Length == amount)　//もし敵を１体も倒せなかったら
            {
                skillcheat.GetComponent<PV_SkillCheat>().cheat();　//スキルを配布する
            }
            */
            gameObject.SetActive(false);　//タイマーのスクリプトを消す
        }
    }

    public void warp()
    {
        tip2.SetActive(false); //左上のヒントを消す
        player.GetComponent<CharacterController>().enabled = false; //プレイヤーを動かすためにキャラコンを消す
        Vector3 point = warppoint.transform.position; //warppointにポジションを変える
        player.transform.position = point;
        mediumbosssystem.SetActive(true); //ボス召喚
        player.GetComponent<CharacterController>().enabled = true; //プレイヤーのキャラコンを戻す
    }
}
