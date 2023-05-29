using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKill : MonoBehaviour
{
    //スキル取得
    private int value;

    //カジキ
    public Text amount_Kajiki;　//残りの数を表記するテキスト
    private int a_Kajiki; //数を計算する

    //ウナギ
    public Text amount_Unagi;　//残りの数を表記するテキスト
    private int a_Unagi; //数を計算する

    //クラゲ
    public Text amount_Kurage;　//残りの数を表記するテキスト
    private int a_Kurage; //数を計算する


    //敵が死んだら
    private GameObject enemy1prefab;

    // Start is called before the first frame update
    void Start()
    {
        a_Kajiki = 0;
        a_Kurage = 0;
        a_Unagi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        enemy1prefab = GameObject.FindGameObjectWithTag("Enemy1");
        if (enemy1prefab.GetComponent<EnemyHP>().HP <= 0)
        {
            getskill();
            Debug.Log("Dead");
        }
        */
    }

    public void getskill()
    {
        Debug.Log("Hi");

        //カジキ
        value = Random.Range(5, 10);
        a_Kajiki += value; //スキルの数＋value
        amount_Kajiki.text = "" + a_Kajiki;　//スキルの数を表記するテキストの中身を変更

        //ウナギ
        value = Random.Range(5, 10);
        a_Unagi += value; //スキルの数＋value
        amount_Unagi.text = "" + a_Unagi;　//スキルの数を表記するテキストの中身を変更

        //クラゲ
        value = Random.Range(5, 10);
        a_Kurage += value; //スキルの数＋value
        amount_Kurage.text = "" + a_Kurage;　//スキルの数を表記するテキストの中身を変更
    }
}
