using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitDamage : MonoBehaviour
{
    public float bosshitcount = 3;
    public float enemyhitcount = 1;
    public GameObject canvas_bosshit;
    public Slider slider_bosshit;
    public GameObject canvas_enemyhit;
    public Slider slider_enemyhit;
    private GameObject player;
    public GameObject[] amount_boss;
    private GameObject[] amount_mediumboss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            canvas_bosshit.SetActive(true); //ダメージ警告表示
            bosshitcount -= Time.deltaTime;
            slider_bosshit.value = bosshitcount;
            if (bosshitcount <= 0)
            {
                player.GetComponent<PlayerHP>().fivedamage(); //５ダメ食らう
                bosshitcount = 3; //カウント3に戻す
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            canvas_enemyhit.SetActive(true); //ダメージ警告表示
            enemyhitcount -= Time.deltaTime;
            slider_enemyhit.value = enemyhitcount;
            if (enemyhitcount <= 0)
            {
                player.GetComponent<PlayerHP>().fivedamage(); //５ダメ食らう
                enemyhitcount = 1; //カウント1に戻す
            }
        }
    }

    //ボス、雑魚敵との重なりが終わった時
    public void OnTriggerExit(Collider other)
    {
        //↓ボス、中ボスの処理
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            bosshitcount = 3; //カウントを3に戻す
            canvas_bosshit.SetActive(false); //ダメージ警告非表示
        }

        //↓雑魚敵の処理
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyhitcount = 1; //カウントを1に戻す
            canvas_enemyhit.SetActive(false); //ダメージ警告非表示
        }
    }

    //↓雑魚敵が死んだときに実行
    public void EnemyDead()
    {
        enemyhitcount = 1; //カウントを1に戻す
        canvas_enemyhit.SetActive(false); //ダメージ警告非表示
    }
}
