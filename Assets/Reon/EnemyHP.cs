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

    /*
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
    */


    //EnemyKill
    private GameObject enemykill;

    //はるまサウンド用変数
    public static int damaged_Sound_E;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        enemykill = GameObject.Find("EnemyKillSystem");
    }

    // Update is called once per frame
    void Update()
    {
        //死ぬ処理
        if (HP <= 0)
        {
            //getskill();
            enemykill.GetComponent<EnemyKill>().getskill();
            Destroy(Enemy);
            damaged_Sound_E = 2;
        }

        //攻撃されたとき
        if (HP <= 90)
        {
            this.GetComponent<FishMove>().getdamage = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (Player.GetComponent<SkillElectronic_new>().IsLightning == false)
            {
                HP = HP - 10;
                HPBar.value = HP;
                damaged_Sound_E = 1;
            }
            if (Player.GetComponent<SkillElectronic_new>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
                damaged_Sound_E = 1;
            }
        }
    }

    /*
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
    */
}
