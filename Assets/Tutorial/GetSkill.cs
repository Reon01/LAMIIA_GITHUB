using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSkill : MonoBehaviour
{
    //カジキ
    public Text amount_Kajiki;　//残りの数を表記するテキスト
    public int a_Kajiki; //数を計算する
    private bool isKajiki; //取得エリアにいるかいないか判断する

    //ウナギ
    public Text amount_Unagi;　//残りの数を表記するテキスト
    public int a_Unagi; //数を計算する
    private bool isUnagi; //取得エリアにいるかいないか判断する

    //クラゲ
    public Text amount_Kurage;　//残りの数を表記するテキスト
    public int a_Kurage; //数を計算する
    private bool isKurage; //取得エリアにいるかいないか判断する

    //カメ
    public Text amount_Kame;　//残りの数を表記するテキスト
    public int a_Kame; //数を計算する
    private bool isKame; //取得エリアにいるかいないか判断する

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //カジキ
        if (isKajiki == true && Input.GetKeyDown(KeyCode.E))　//　カジキエリアに入ってるときにEを押したらスキルが１もらえる
        {
            a_Kajiki += 1;　//スキルの数＋１
            amount_Kajiki.text = "" + a_Kajiki;　//スキルの数を表記するテキストの中身を変更
        }

        //ウナギ
        if (isUnagi == true && Input.GetKeyDown(KeyCode.E))　//　ウナギエリアに入ってるときにEを押したらスキルが１もらえる
        {
            a_Unagi += 1;　//スキルの数＋１
            amount_Unagi.text = "" + a_Unagi;　//スキルの数を表記するテキストの中身を変更
        }

        //クラゲ
        if (isKurage == true && Input.GetKeyDown(KeyCode.E))　//　クラゲエリアに入ってるときにEを押したらスキルが１もらえる
        {
            a_Kurage += 1;　//スキルの数＋１
            amount_Kurage.text = "" + a_Kurage;　//スキルの数を表記するテキストの中身を変更
        }

        //カメ
        if (isKame == true && Input.GetKeyDown(KeyCode.E))　//　カメエリアに入ってるときにEを押したらスキルが１もらえる
        {
            a_Kame += 1;　//スキルの数＋１
            amount_Kame.text = "" + a_Kame;　//スキルの数を表記するテキストの中身を変更
        }


        //カジキのスキルを使ったら、表記をー１する
        if (GetComponent<Kajiki>().spendskill == true)
        {
            amount_Kajiki.text = "" + a_Kajiki;
        }

        /*
        //カメのスキルを使ったら、表記を-1する
        if (GetComponent<Kame2>().spendskill == true)
        {
            amount_Kame.text = "" + a_Kame;
        }
        */
    }

    //　↓カジキのエリアに入ったらスキルを取得できるようにする
    public void OnTriggerEnter(Collider other)
    {
        //カジキ
        if (other.gameObject.CompareTag("Kajiki"))
        {
            isKajiki = true;
        }

        //ウナギ
        if (other.gameObject.CompareTag("Unagi"))
        {
            isUnagi = true;
        }

        //クラゲ
        if (other.gameObject.CompareTag("Kurage"))
        {
            isKurage = true;
        }

        //カメ
        if (other.gameObject.CompareTag("kame"))
        {
            isKame = true;
        }
    }

    //　↓カジキのエリアから出たら取得できないようにする
    public void OnTriggerExit(Collider other)
    {
        //カジキ
        if (other.gameObject.CompareTag("Kajiki"))
        {
            isKajiki = false;
        }

        //ウナギ
        if (other.gameObject.CompareTag("Unagi"))
        {
            isUnagi = false;
        }

        //クラゲ
        if (other.gameObject.CompareTag("Kurage"))
        {
            isKurage = false;
        }

        //カメ
        if (other.gameObject.CompareTag("kame"))
        {
            isKame = false;
        }
    }
}
