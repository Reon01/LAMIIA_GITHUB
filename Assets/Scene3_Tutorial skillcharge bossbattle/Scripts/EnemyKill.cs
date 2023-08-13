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
    public int a_Kajiki; //数を計算する

    //ウナギ
    public Text amount_Unagi;　//残りの数を表記するテキスト
    public int a_Unagi; //数を計算する

    //クラゲ
    public Text amount_Kurage;　//残りの数を表記するテキスト
    public int a_Kurage; //数を計算する


    //敵が死んだら
    private GameObject enemy1prefab;


    //サウンド用
    public static bool e_Defeat_Sound = false;

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
        amount_Kajiki.text = "" + a_Kajiki;　//スキルの数を表記するテキストの中身を変更
        amount_Unagi.text = "" + a_Unagi;　//スキルの数を表記するテキストの中身を変更
        amount_Kurage.text = "" + a_Kurage;　//スキルの数を表記するテキストの中身を変更
    }

    public void getskill()
    {
        //カジキ
        value = Random.Range(2, 4);
        a_Kajiki += value; //スキルの数＋value

        //ウナギ
        value = Random.Range(3, 5);
        a_Unagi += value; //スキルの数＋value

        //クラゲ
        value = Random.Range(1, 2);
        a_Kurage += value; //スキルの数＋value


        //サウンド用
        e_Defeat_Sound = true;
    }
}
