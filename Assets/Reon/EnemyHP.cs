using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float HP = 100;
    public Slider HPBar;
    public GameObject Enemy;
    private GameObject Player;

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

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //死ぬ処理
        if (HP <= 0)
        {
            getskill();
            Destroy(Enemy);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (Player.GetComponent<SkillElectronic>().IsLightning == false)
            {
                HP = HP - 10;
                HPBar.value = HP;
            }
            if (Player.GetComponent<SkillElectronic>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
            }
        }
    }

    public void getskill()
    {
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
