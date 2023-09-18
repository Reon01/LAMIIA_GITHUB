
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuteFishHP : MonoBehaviour
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
            enemykill.GetComponent<EnemyKillTute>().getskill();
            Destroy(Enemy);
        }

        //攻撃されたとき
        if (HP <= 90)
        {
            //this.GetComponent<FishMove>().getdamage = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (Player.GetComponent<InputSkillElectronic>().IsLightning == false)
            {
                HP = HP - 10;
                HPBar.value = HP;
            }
            if (Player.GetComponent<InputSkillElectronic>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
            }
        }

        //↓カジキの場合50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            HP -= 50;
            HPBar.value = HP;
        }

        //↓ウナギの場合20DMG
        if (other.gameObject.CompareTag("UnagiAttack"))
        {
            HP -= 20;
            HPBar.value = HP;
            //damagedisplay20(); //２０ダメージのテキストを表示

            //サウンド用
            SFXplayer.damaged_Sound_E = 1;
            SkillElectronic.EE_Sound = 2;
        }
    }

   
}