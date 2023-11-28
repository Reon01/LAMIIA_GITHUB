using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSkill : MonoBehaviour
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


    public GameObject SkillEfect;

    public float speed = 5f; // エフェクトの移動速度
    private Transform player; // プレイヤーのTransform

    public void EnemyDefeated(GameObject enemy)
    {
        GameObject skillEffect = Instantiate(SkillEfect, enemy.transform.position, Quaternion.identity);

        if (player != null)
        {
            // プレイヤーの方向を向く
            transform.LookAt(player);

            // プレイヤーの方向に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // 一定の時間が経過したらエフェクトを破棄
        Destroy(skillEffect, 2f);

        // スキルの取得処理を実行
        GainSkill();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        amount_Kajiki.text = "" + a_Kajiki;　//スキルの数を表記するテキストの中身を変更
        amount_Unagi.text = "" + a_Unagi;　//スキルの数を表記するテキストの中身を変更
        amount_Kurage.text = "" + a_Kurage;　//スキルの数を表記するテキストの中身を変更
        */


    }
    void GainSkill()
    {
        //カジキ
        if (isKajiki == true && Input.GetKeyDown(KeyCode.E)) //　カジキエリアに入ってるときにEを押したらスキルが１もらえる
        {
            a_Kajiki += 1; //スキルの数＋１
        }

        //ウナギ
        if (isUnagi == true && Input.GetKeyDown(KeyCode.E)) //　ウナギエリアに入ってるときにEを押したらスキルが１もらえる
        {
            a_Unagi += 1; //スキルの数＋１
        }

        //クラゲ
        if (isKurage == true && Input.GetKeyDown(KeyCode.E)) //　クラゲエリアに入ってるときにEを押したらスキルが１もらえる
        {
            a_Kurage += 1; //スキルの数＋１
        }

        //カジキのスキルを使ったら、表記をー１する
        if (GetComponent<Kajiki>().spendskill == true)
        {
            amount_Kajiki.text = "" + a_Kajiki;
        }
    }

    //　↓カジキのエリアに入ったらスキルを取得できるようにする
    void OnTriggerEnter(Collider other)
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
    }

    //　↓カジキのエリアから出たら取得できないようにする
    void OnTriggerExit(Collider other)
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
    }
}
